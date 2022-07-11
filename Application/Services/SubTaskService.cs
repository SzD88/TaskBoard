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

        public async Task DeleteAsync(object id)
        {
            var guid = (Guid)id; 
            var toDelete = await _notes.GetByIDAsync(guid);
            await _notes.DeleteAsync(toDelete);
        }

        public async Task<IEnumerable<SubTaskDto>> GetAllAsync()
        {
          var allNotes = await _notes.GetAllAsync();
          return  _mapper.Map<IEnumerable<SubTaskDto>>(allNotes); 
        } 
        public async Task<SubTaskDto> GetByIDAsync(object id)
        { 
            var subTask = await _notes.GetByIDAsync(id);
            // mam subtask
            //wygeneruj mu liste
            var list = await CreateListOfTasks(subTask.Id);
            //przypisz mu liste
            subTask.IncludedTasks =  list.ToList() ;// #check
            //zwróc go z lista

            return _mapper.Map<SubTaskDto>(subTask);
        }
         
        public async Task UpdateAsync(UpdateSubTaskDto entityToUpdate)
        {
            var subTaskType = _mapper.Map<SubTask>(entityToUpdate); 
            await _notes.UpdateAsync(subTaskType); 
        }

        internal async Task<IEnumerable<SubTaskDto>> CreateListOfTasks(Guid parentId)
        {
            var list = await _notes.GetAllAsync();
            return _mapper.Map<IEnumerable<SubTaskDto>>(list);
        }
    }
}
