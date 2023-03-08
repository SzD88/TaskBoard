using Application.Commands;
using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using Domain.Interfaces;

namespace Application.Services;

internal partial class DayService : IDayService
{
    private readonly IDayRepository _projects;
    private readonly ISubTaskRepository _subTasks;
    public DayService(IDayRepository projectRepository, ISubTaskRepository subTaskRepository)
    {
        _projects = projectRepository;
        _subTasks = subTaskRepository;
    }
    public async Task<DayDto> CreateAsync(CreateDay project)
    {
        var asProjectType = Map.CreateProjectDtoToProject(project);
        var created = await _projects.CreateAsync(asProjectType);

        return Map.ProjectToProjectDto(created);
    }
    public async Task DeleteAsync(Guid id)
    {
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
        var allProjects = await _projects.GetAllAsync();
        var mappedProjects = Map.ListConvert(allProjects);
        var daysAhead = weeksAhead * 7;

        if (weeksAhead > 3)
        {
            return null;
        }
        foreach (var projectObject in mappedProjects)
        {
           // var listofSubTasksToMapAsDtos = await _subTasks.CreateListOfTasks(projectObject.Id);
            var listofSubTasksToMapAsDtos = await _subTasks.CreateListOfTasksByDate(projectObject.DayDate);
             
            var mappedListOfIncludedSubTasks = Map.ListConvert(listofSubTasksToMapAsDtos);
             
            //#selekcja
            var selectedOnlyNotCompletedTasks = mappedListOfIncludedSubTasks.Where(o => o.Completed == false).ToList();

            projectObject.MainTasks = selectedOnlyNotCompletedTasks;
        }

        var orderedDays = mappedProjects.OrderBy(o => o.DayDate).ToList();

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


    public async Task<DayDto> GetByIDAsync(Guid id)
    {
        var project = await _projects.GetByIDAsync(id);
        if (project == null) return null;

        var projectDtoType = Map.ProjectToProjectDto(project);

        var list = await _subTasks.CreateListOfTasks(project.Id);

        var mappedList = Map.ListConvert(list);

        foreach (var item in mappedList)
        {
            projectDtoType.MainTasks.Add(item);
        }
        return projectDtoType;
    }
    public async Task UpdateAsync(UpdateDayDto entityToUpdate)
    {
        var project = Map.UpdateProjectDtoToProject(entityToUpdate);

        await _projects.UpdateAsync(project);
    }
    public async Task DeleteAllProjectsAsync()
    {
        var allProjects = await _projects.GetAllAsync();

        foreach (var project in allProjects)
        {
            var id = (Guid)project.Id;
            await _projects.DeleteAsync(id);
        }
    }
}