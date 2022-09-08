using Application.Dto;

namespace Application.Interfaces;

public interface ISubTaskService
{
  Task<SubTaskDto> CreateAsync(CreateSubTaskDto entity);
  Task DeleteAsync(Guid id);
  Task<IEnumerable<SubTaskDto>> GetAllAsync();
  Task<SubTaskDto> GetByIDAsync(Guid id);
  Task UpdateAsync(UpdateSubTaskDto entityToUpdate);
  Task DeleteAllSubTasksAsync();
  Task CreateExampleSubTasksAsync();
  Task<bool> ChangeCompletedStateAsync(Guid id);
}
