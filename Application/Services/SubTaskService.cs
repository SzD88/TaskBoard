using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System.Linq.Expressions;

namespace Application.Services
{


    public class SubTaskService : ISubTaskService
    {
        private readonly ISubTaskRepository _notes;
        private readonly IMapper _mapper;
        public SubTaskService(ISubTaskRepository notesRepository, IMapper mapper ) //  IMapper mapper
        {
            _notes = notesRepository;
            _mapper = mapper;
        }

        public async Task<SubTaskDto> CreateAsync(CreateSubTaskDto note)
        {
            var noteAsNote = _mapper.Map<SubTask>(note);
            var created = await _notes.CreateAsync(noteAsNote);
            return _mapper.Map<SubTaskDto>(created); 
        }
        public async Task DeleteAsync(Guid id)
        {
          await _notes.DeleteAsync(id);
        }

        public Task DeleteAsync(object id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SubTaskDto>> GetAllAsync()
        {
          var allNotes = await _notes.GetAllAsync();
          return  _mapper.Map<IEnumerable<SubTaskDto>>(allNotes); 
        } 
        public async Task<SubTaskDto> GetByIDAsync(object id)
        { 
            var note = await _notes.GetByIDAsync(id); 

            return _mapper.Map<SubTaskDto>(note);
        }
         
        public async Task UpdateAsync(SubTaskDto entityToUpdate)
        {
            var notetype = _mapper.Map<SubTask>(entityToUpdate);

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
