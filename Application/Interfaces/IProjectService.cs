using Application.Dto;

namespace Application.Interfaces;

public interface IProjectService
{
  Task<ProjectDto> CreateAsync(CreateProjectDto entity);
  Task DeleteAsync(Guid id);
  Task<IEnumerable<ProjectDto>> GetAllAsync(); // #refactor
  Task<ProjectDto> GetByIDAsync(object id);
  Task UpdateAsync(UpdateProjectDto entityToUpdate);
  Task DeleteAllProjectsAsync();
  Task CreateExampleProjectsAsync();
  Task<IEnumerable<ProjectDto>> GetAllSortedAsync(string sortField, bool ascending);
}
