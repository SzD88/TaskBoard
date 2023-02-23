using Application.Commands;
using Application.Dto;

namespace Application.Interfaces;

public interface IDayService
{
    Task<DayDto> CreateAsync(CreateDay entity);
    Task DeleteAsync(Guid id);
    Task<IReadOnlyList<DayDto>> GetAllAsync();
    Task<IReadOnlyList<DayDto>> GetWeek(int weeksAhead);
    Task<DayDto> GetByIDAsync(Guid id);
    Task UpdateAsync(UpdateDayDto entityToUpdate);
    Task DeleteAllProjectsAsync();
}
