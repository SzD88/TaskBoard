using Application.Dto;

namespace Application.Interfaces;

public interface IProjectService
{
  Task<ProjectDto> CreateAsync(CreateProjectDto entity);
  Task DeleteAsync(Guid id);
  Task<IReadOnlyList<ProjectDto>> GetAllAsync(); // #refactor
  Task<ProjectDto> GetByIDAsync(Guid id);
  Task UpdateAsync(UpdateProjectDto entityToUpdate);
  Task DeleteAllProjectsAsync();
 // Task<IReadOnlyList<ProjectDto>> GetAllSortedAsync(string sortField, bool ascending);
}
