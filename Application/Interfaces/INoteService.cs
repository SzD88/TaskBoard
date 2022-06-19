using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetAllNotes();
        Task<NoteDto> AddNote(CreateNoteDto note);
        Task EditNote(NoteDto note);
        Task Delete(int id);
        Task MarkAsDone(bool done);
    }
}
