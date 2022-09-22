using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<IReadOnlyList<Project>> GetAllSortedAsync(string sortField, bool ascending); 
        //Task<IReadOnlyList<SubTask>> CreateListOfMainTasks(Guid parentId);
    }
}
