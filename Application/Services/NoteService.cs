using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{


    public class NoteService : INoteService
    {
        private readonly INotesRepository _notes;
        private readonly IMapper _mapper;
        public NoteService(INotesRepository notesRepository, IMapper mapper ) //  IMapper mapper
        {
            _notes = notesRepository;
            _mapper = mapper;
        }

        public async Task<NoteDto> CreateAsync(CreateNoteDto note)
        {
            var noteAsNote = _mapper.Map<Note>(note);
            var created = await _notes.CreateAsync(noteAsNote);
            return _mapper.Map<NoteDto>(created); 
        }
        public async Task DeleteAsync(Guid id)
        {
          await _notes.DeleteAsync(id);
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NoteDto>> GetAllAsync()
        {
          var allNotes = await _notes.GetAllAsync();
          return  _mapper.Map<IEnumerable<NoteDto>>(allNotes); 
        } 
        public async Task<NoteDto> GetByIDAsync(object id)
        { 
            var note = await _notes.GetByIDAsync(id); 

            return _mapper.Map<NoteDto>(note);
        }
         
        public async Task UpdateAsync(NoteDto entityToUpdate)
        {
            var notetype = _mapper.Map<Note>(entityToUpdate);

            await _notes.UpdateAsync(notetype);


        }



        //Task<CreateNoteDto> IRepository<CreateNoteDto>.GetByID(object id)
        //{
        //    throw new NotImplementedException();
        //}


        // var note = new Note(noteDto.Content); 
        //var n2 =  await _notes.Create(note); 
        // var noteToReturn = new NoteDto(n2.Id, n2.Content, n2.Completed);
        // return noteToReturn;


    }
}
