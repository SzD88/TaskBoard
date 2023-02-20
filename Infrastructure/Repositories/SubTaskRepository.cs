using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class SubTaskRepository : ISubTaskRepository
    {
        private readonly TaskBoardContext _context;
        public SubTaskRepository(TaskBoardContext context)
        {
            _context = context;
        }
        public async Task<SubTask> CreateAsync(SubTask entity)
        {
            await _context.SubTasks.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Guid idToDelete)
        {
            var subTaskToDelete = await GetByIDAsync(idToDelete);
            _context.Remove(subTaskToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SubTask>> GetAllAsync()
        {
            return await _context.SubTasks.ToListAsync();
        }
        public async Task<SubTask> GetByIDAsync(Guid id)
        {
            var guid = (Id)id;
            var toReturn = await _context.SubTasks.FirstOrDefaultAsync(x => x.Id == guid);
            return toReturn;
        }
        public async Task UpdateAsync(SubTask entityToUpdate)
        {
            entityToUpdate.LastModified = DateTime.Now;
            _context.SubTasks.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SubTask>> CreateListOfTasks(Guid parentId)
        {
            var tmpId = (Id)parentId;
            var listOfChilds = await _context.SubTasks
                .Where(x => x._levelAboveId == tmpId)
                .ToListAsync();

            foreach (var subtask in listOfChilds)
            {
                var listBelow = await CreateListOfTasks(subtask.Id);

                foreach (var itemBelow in listBelow)
                {
                    subtask.AddSubTask(itemBelow.GetSubTaskId());
                }
            }
            return listOfChilds;
        }

    }
}
