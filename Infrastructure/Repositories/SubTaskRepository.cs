using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class SubTaskRepository : ISubTaskRepository
    {
        private readonly ProjectManagerContext _context;
        public SubTaskRepository(ProjectManagerContext context)
        {
            _context = context;
        }

        public async Task<SubTask> CreateAsync(SubTask entity)
        {
            entity.EditCompleted(false);
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            await _context.SubTasks.AddAsync(entity); //(SubTask)
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Guid subTaskToDelete) // tu ma wejsc note
        {
            _context.Remove(subTaskToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SubTask>> GetAllAsync()
        {
            return await _context.SubTasks.ToListAsync();
        }
        public async Task<SubTask> GetByIDAsync(Guid id)
        {
            var guid = (Guid)id;
            var toReturn = await _context.SubTasks.FirstOrDefaultAsync(x => x.GetSubTaskId() == guid);
            //   if (toReturn == null) throw new Exception("Not found sd");
            return toReturn;
        }
        public async Task UpdateAsync(SubTask entityToUpdate)
        {
            _context.SubTasks.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<SubTask>> CreateListOfTasks(Guid parentId)
        {
            var list = await _context.SubTasks
                .Where(x => x._levelAboveId == parentId) // #problem // nie mozesz tak zrobic przeciez
                //#sorthere
                .ToListAsync(); 
             
            foreach (var subtask in list)
            {
                var listBelow = await CreateListOfTasks(subtask.Id);

                foreach (var itemBelow in listBelow)
                {
                    subtask.AddSubTask(itemBelow.GetSubTaskId());
                }
            }
            return list;
        }
 
    }
}
