using Application.Dto;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class NoteService : INoteService
    {
        private readonly INotesRepository _notes;
        public NoteService(INotesRepository notesRepository)
        {
            _notes = notesRepository;
        }
        public async Task<NoteDto> AddNote(CreateNoteDto noteDto)
        {
            
            var note = new Note(noteDto.Content);
           
           var n2 =  await _notes.AddNote(note);

            var noteToReturn = new NoteDto(n2.Id, n2.Content, n2.Completed);
            return noteToReturn;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditNote(NoteDto note)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoteDto>> GetAllNotes()
        {
            throw new NotImplementedException();
        }

        public Task MarkAsDone(bool done)
        {
            throw new NotImplementedException();
        }
    }
}
