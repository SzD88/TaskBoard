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
    public class NotesRepository : INotesRepository
    {
        private readonly ProjectManagerContext _context;
        public NotesRepository(ProjectManagerContext context)
        {
            _context = context;
        }
        public async Task<Note> CreateAsync(Note entity)
        {
            entity.Completed = false;
            entity.Created = DateTime.Now;
            entity.LastModified = DateTime.Now;
            await _context.Notes.AddAsync((Note)entity);
            await _context.SaveChangesAsync();
            return entity;
        } 
        public async Task DeleteAsync(object note) // tu ma wejsc note
        {
            Note noteMiror = (Note)note;
            var toDelete = _context.Notes.FirstOrDefaultAsync(x => x.Id == noteMiror.Id);
            if (toDelete == null) throw new Exception("Not found sd");
            _context.Remove(toDelete);
            await _context.SaveChangesAsync();
        } 
        public async Task<IEnumerable<Note>> GetAllAsync()
        {
            return await _context.Notes.ToListAsync();
        } 
        public async Task<Note> GetByIDAsync(object id)
        {
            Note noteMiror = (Note)id;
            var toReturn = await _context.Notes.FirstOrDefaultAsync(x => x.Id == noteMiror.Id);
            if (toReturn == null) throw new Exception("Not found sd"); 
            return toReturn; 
        } 
        public async Task UpdateAsync(Note entityToUpdate)
        {
            _context.Notes.Update(entityToUpdate);
            await _context.SaveChangesAsync(); 
        }
    }
}
