using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using Domain.Interfaces;

namespace Application.Services;

internal class ProjectService : IProjectService
{
    private readonly IProjectRepository _projects;
    private readonly ISubTaskRepository _subTasks;
    public ProjectService(IProjectRepository projectRepository, ISubTaskRepository subTaskRepository)
    {
        _projects = projectRepository;
        _subTasks = subTaskRepository;
    }
    public async Task<ProjectDto> CreateAsync(CreateProjectDto project)
    {
        var asProjectType = Map.CreateProjectDtoToProject(project);
        var created = await _projects.CreateAsync(asProjectType);

        return Map.ProjectToProjectDto(created);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _projects.DeleteAsync(id);
    }

    public async Task<IReadOnlyList<ProjectDto>> GetAllAsync()
    {
        var allProjects = await _projects.GetAllAsync();
        var mappedProjects = Map.ListConvert(allProjects);

        foreach (var projectObject in mappedProjects)
        {
            var listofSubTasksToMapAsDtos = await _subTasks.CreateListOfTasks(projectObject.Id);
            var mappedListOfIncludedSubTasks = Map.ListConvert(listofSubTasksToMapAsDtos);

            projectObject.MainTasks = mappedListOfIncludedSubTasks;
        }

        return mappedProjects;
    }
    public async Task<ProjectDto> GetByIDAsync(Guid id)
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
    public async Task UpdateAsync(UpdateProjectDto entityToUpdate)
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
