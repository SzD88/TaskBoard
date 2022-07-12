using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubTaskRepository : ISubTaskRepository
    {
        private readonly ProjectManagerContext _context;
        public SubTaskRepository(ProjectManagerContext context)
        {
            _context = context;
        }
        public async Task<SubTask> CreateAsync(SubTask entity)
        {
            entity.Completed = false;
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            await _context.SubTasks.AddAsync(entity); //(SubTask)
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(object subTaskToDelete) // tu ma wejsc note
        { 
            _context.Remove(subTaskToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SubTask>> GetAllAsync()
        {
            return await _context.SubTasks.ToListAsync();
        }
        public async Task<SubTask> GetByIDAsync(object id)
        {
            var guid = (Guid)id; 
            var toReturn = await _context.SubTasks.FirstOrDefaultAsync(x => x.Id == guid);
            if (toReturn == null) throw new Exception("Not found sd");
            return toReturn;
        }
        public async Task UpdateAsync(SubTask entityToUpdate)
        {
            _context.SubTasks.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<SubTask>> CreateListOfTasks(Guid parentId)
        {
            var list =  await _context.SubTasks
                .Where(x => x.LevelAboveId == parentId)
                .ToListAsync(); 
            return list;
        }
    }
}
