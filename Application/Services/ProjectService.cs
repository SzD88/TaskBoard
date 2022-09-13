﻿using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;


namespace Application.Services;

internal class ProjectService : IProjectService
{
    private readonly IProjectRepository _projects;
    private readonly IMapper _mapper;
    private readonly ISubTaskRepository _subTasks;
    public ProjectService(IProjectRepository projectRepository, IMapper mapper, ISubTaskRepository subTaskRepository)
    {
        _projects = projectRepository;
        _mapper = mapper;
        _subTasks = subTaskRepository;
    }
    public async Task<ProjectDto> CreateAsync(CreateProjectDto project)
    {
        var asProjectType = _mapper.Map<Project>(project);
        var created = await _projects.CreateAsync(asProjectType);
        return _mapper.Map<ProjectDto>(created);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _projects.DeleteAsync(id); 
    }

    public async Task<IReadOnlyList<ProjectDto>> GetAllAsync()
    {

        var allProjects = await _projects.GetAllAsync();
        var mappedProjects = _mapper.Map<IReadOnlyList<ProjectDto>>(allProjects);

        foreach (var item in mappedProjects)
        {
            var list = await _subTasks.CreateListOfTasks(item.Id);
            var mappedList = _mapper.Map<IReadOnlyList<SubTaskDto>>(list);

            foreach (var lists in mappedList)
            {
                item.MainTasks.Add(lists);
            }
        }
        return mappedProjects;

    }
    public async Task<IReadOnlyList<ProjectDto>> GetAllSortedAsync(string sortField, bool ascending)
    {
        var allProjects = await _projects.GetAllSortedAsync(sortField, ascending);
        var mappedProjects = _mapper.Map<IReadOnlyList<ProjectDto>>(allProjects);

        foreach (var item in mappedProjects)
        {
            var list = await _subTasks.CreateListOfTasks(item.Id);
            var mappedList = _mapper.Map<IReadOnlyList<SubTaskDto>>(list);

            foreach (var lists in mappedList)
            {
                item.MainTasks.Add(lists);
            }
        }
        return mappedProjects;

    }

    public async Task<ProjectDto> GetByIDAsync(Guid id)
    {
        var project = await _projects.GetByIDAsync(id);

        var projectDtoType = _mapper.Map<ProjectDto>(project);

        var list = await _subTasks.CreateListOfTasks(project.Id);

        var mappedList = _mapper.Map<IEnumerable<SubTaskDto>>(list);

        foreach (var item in mappedList)
        {
            projectDtoType.MainTasks.Add(item);
        }
        return projectDtoType;
    }

    public async Task UpdateAsync(UpdateProjectDto entityToUpdate)
    {

        var existinProject = await _projects.GetByIDAsync(entityToUpdate.Id);

        var project = _mapper.Map(entityToUpdate, existinProject);

        await _projects.UpdateAsync(project);


    }

    public async Task DeleteAllProjectsAsync()  
    {
        var allProjects = await _projects.GetAllAsync();

        foreach (var project in allProjects)
        {
            await _projects.DeleteAsync(project.Id);
        }
    }
 
}
