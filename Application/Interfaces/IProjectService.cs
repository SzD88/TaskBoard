﻿using Application.Commands;
using Application.Dto;

namespace Application.Interfaces;

public interface IProjectService
{
  Task<ProjectDto> CreateAsync(CreateProject entity);
  Task DeleteAsync(Guid id);
  Task<IReadOnlyList<ProjectDto>> GetAllAsync(); 
  Task<ProjectDto> GetByIDAsync(Guid id);
  Task UpdateAsync(UpdateProjectDto entityToUpdate);
  Task DeleteAllProjectsAsync(); 
}
