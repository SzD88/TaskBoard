using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ISubTaskRepository : IRepository<SubTask>
    {
        Task<IReadOnlyList<SubTask>> CreateListOfTasks(Guid parentId);
    }
}
