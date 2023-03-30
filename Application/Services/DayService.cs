using Application.Commands;
using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;


namespace Application.Services;

internal partial class DayService : IDayService
{
    private readonly IDayRepository _projects;
    private readonly ISubTaskRepository _subTasks;
    private readonly IMemoryCache _memoryCache;

    public DayService(IDayRepository projectRepository, ISubTaskRepository subTaskRepository, IMemoryCache memoryCache)
    {
        _projects = projectRepository;
        _subTasks = subTaskRepository;
        _memoryCache = memoryCache;
    }
    public async Task<DayDto> CreateAsync(CreateDayDto project)
    {
        var asProjectType = Map.CreateDayDtoToDay(project);
        var created = await _projects.CreateAsync(asProjectType);
        ClearCache(); 
        return Map.DayToDayDto(created);
    }
    public async Task DeleteAsync(Guid id)
    {
        ClearCache(); 
        await _projects.DeleteAsync(id);
    }

    public async Task<IReadOnlyList<DayDto>> GetAllAsync()
    {
        var allProjects = await _projects.GetAllAsync();
        var mappedProjects = Map.ListConvert(allProjects);

        foreach (var projectObject in mappedProjects)
        {
            var listofSubTasksToMapAsDtos = await _subTasks.CreateListOfTasks(projectObject.Id);
            var mappedListOfIncludedSubTasks = Map.ListConvert(listofSubTasksToMapAsDtos);

            projectObject.MainTasks = mappedListOfIncludedSubTasks;
        }
        return mappedProjects.OrderBy(o => o.DayDate).ToList();
    }
    public async Task<IReadOnlyList<DayDto>> GetWeek(int weeksAhead)
    {
        var days = _memoryCache.Get<IReadOnlyList<Day>>("days");

        if (days == null)
        {
            days = await _projects.GetAllAsync();
            _memoryCache.Set("days", days, TimeSpan.FromMinutes(5));

        }

        var mapedDays = Map.ListConvert(days);
        var daysAhead = weeksAhead * 7;

        if (weeksAhead > 3)
        {
            return null;
        }
        foreach (var dayObject in mapedDays)
        {
            var listofSubTasksToMapAsDtos = await _subTasks.CreateListOfTasksByDate(dayObject.DayDate);

            var mappedListOfIncludedSubTasks = Map.ListConvert(listofSubTasksToMapAsDtos);

            var selectedOnlyNotCompletedTasks = mappedListOfIncludedSubTasks.Where(o => o.Completed == false).ToList();

            var listSortedByWords = SortByWords(selectedOnlyNotCompletedTasks);

            dayObject.MainTasks = listSortedByWords;
        }

        var orderedDays = mapedDays.OrderBy(o => o.DayDate).ToList();

        var mondayOfCurrentWeek = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

        var mondayOfSelectedWeek = mondayOfCurrentWeek.AddDays(daysAhead);

        var mondayOfDBDays = orderedDays.FirstOrDefault(x => x.DayDate == mondayOfSelectedWeek);

        var indexOfSerchedMonday = orderedDays.IndexOf(mondayOfDBDays);

        var selectedWeek = new List<DayDto>();
        if (indexOfSerchedMonday < 0)
        {
            return null;
        }
        for (int i = 0; i < 7; i++)
        {
            selectedWeek.Add(orderedDays[indexOfSerchedMonday]);
            indexOfSerchedMonday++;
        }

        return selectedWeek;
    }
    private List<SubTaskDto> SortByWords(IList<SubTaskDto> list)
    {
        string word1 = " OUT";
        string word2 = " HO";

        var firstSelected =
        list.Where(x => x.Content.Contains(word1) || x.Content.Contains(word2)).ToList();
        var secondSelected =
        list.Where(x => !x.Content.Contains(word1) && !x.Content.Contains(word2));
        foreach (var item in secondSelected)
        {
            firstSelected.Add(item);
        }
        return firstSelected;
    }
    public async Task<DayDto> GetByIDAsync(Guid id)
    {
        var project = await _projects.GetByIDAsync(id);
        if (project == null) return null;

        var projectDtoType = Map.DayToDayDto(project);

        var list = await _subTasks.CreateListOfTasks(project.Id);

        var mappedList = Map.ListConvert(list);

        foreach (var item in mappedList)
        {
            projectDtoType.MainTasks.Add(item);
        }
        return projectDtoType;
    }
    public async Task<DayDto> GetByDateAsync(DateTime date)
    {
        var projects = await GetAllAsync();

        if (projects == null) return null;

        var selected = projects.FirstOrDefault
            (x => x.DayDate == date);

        return selected;
    }
    public async Task UpdateAsync(UpdateDayDto entityToUpdate)
    {
        var project = Map.UpdateDayDtoToDay(entityToUpdate);
        ClearCache();
        await _projects.UpdateAsync(project);
    }
    public async Task DeleteAllProjectsAsync()
    {
        var allProjects = await _projects.GetAllAsync();

        foreach (var project in allProjects)
        {
            var id = (Guid)project.Id;
            ClearCache();
            await _projects.DeleteAsync(id);
        }
    }
    internal void ClearCache()
    {
        _memoryCache.Remove("days"); 
    }
}