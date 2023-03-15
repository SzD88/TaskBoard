using Domain.Entities;
using Domain.Interfaces;
using Domain.ValueObjects;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal class DayRepository : IDayRepository
    {
        private readonly TaskBoardContext _context;
        public DayRepository(TaskBoardContext context)
        {
            _context = context;
        }
        public async Task<Day> CreateAsync(Day entity)
        { 
            await _context.Days.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task DeleteAsync(Guid idToDelete)
        { 
            var projectToDelete = await GetByIDAsync(idToDelete);
            _context.Remove(projectToDelete); 
            await _context.SaveChangesAsync();
        }

       

        public async Task<IReadOnlyList<Day>> GetAllAsync()
        {
            return await _context.Days.ToListAsync();
        } 
        public async Task<Day> GetByIDAsync(Guid id)
        {
            var guid =  (Id)id;
            var toReturn = await _context.Days.FirstOrDefaultAsync(x => x.Id == guid);
            return toReturn;
        } 
        public async Task UpdateAsync(Day entityToUpdate)
        {
            entityToUpdate.LastModified = DateTime.Now;
            _context.Days.Update(entityToUpdate);
            await _context.SaveChangesAsync();
        }

      
    }
}

