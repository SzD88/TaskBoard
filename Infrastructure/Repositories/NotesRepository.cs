using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly ProjectManagerContext _context;
        public NotesRepository(ProjectManagerContext context)
        {
            _context = context;
        }
        public async Task<Note> AddNote(Note note)
        {
            var count =   _context.Notes.ToList().Count;
           // note.Id = count + 1;
            note.Completed = false;
            note.Created = DateTime.Now;
            note.LastModified = DateTime.Now;

            await  _context.Notes.AddAsync(note);
            _context.SaveChanges();
            return note;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditNote(Note note)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Note>> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public Task MarkAsDone(bool done)
        {
            throw new NotImplementedException();
        }
    }
}
