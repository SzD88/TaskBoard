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
            await _context.SubTasks.AddAsync((SubTask)entity);
            await _context.SaveChangesAsync();
            return entity;
        } 
        public async Task DeleteAsync(object note) // tu ma wejsc note
        {
            SubTask noteMiror = (SubTask)note;
            var toDelete = _context.SubTasks.FirstOrDefaultAsync(x => x.Id == noteMiror.Id);
            if (toDelete == null) throw new Exception("Not found sd");
            _context.Remove(toDelete);
            await _context.SaveChangesAsync();
        } 
        public async Task<IEnumerable<SubTask>> GetAllAsync()
        {
            return await _context.SubTasks.ToListAsync();
        } 
        public async Task<SubTask> GetByIDAsync(object id)
        {
            var guid = (Guid)id;
          //  SubTask noteMiror = new SubTask() { Id = id }; //(SubTask)id;
            var toReturn = await _context.SubTasks.FirstOrDefaultAsync(x => x.Id == guid);
            if (toReturn == null) throw new Exception("Not found sd"); 
            return toReturn; 
        } 
        public async Task UpdateAsync(SubTask entityToUpdate)
        {
            _context.SubTasks.Update(entityToUpdate);
            await _context.SaveChangesAsync(); 
        }
    }
}
