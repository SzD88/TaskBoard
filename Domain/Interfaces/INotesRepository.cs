using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INotesRepository
    {
        Task < IEnumerable<Note> > GetAllNotes(); 
        Task <Note> AddNote(Note note);
        Task   EditNote(Note note);
        Task   Delete(int id);
        Task   MarkAsDone(bool done);

    }
}
