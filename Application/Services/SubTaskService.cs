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
        private readonly ISubTaskRepository _subTasks;
        private readonly IMapper _mapper;
        public SubTaskService(ISubTaskRepository subTasksRepository, IMapper mapper) //  IMapper mapper
        {
            _subTasks = subTasksRepository;
            _mapper = mapper;
        }

        public async Task<SubTaskDto> CreateAsync(CreateSubTaskDto note)
        {
            var noteAsNote = _mapper.Map<SubTask>(note);
            var created = await _subTasks.CreateAsync(noteAsNote);
            return _mapper.Map<SubTaskDto>(created);
        }
        public async Task DeleteAsync(Guid id)
        {
            await _subTasks.DeleteAsync(id);
        }

        public async Task DeleteAsync(object id)
        {
            var guid = (Guid)id;
            var toDelete = await _subTasks.GetByIDAsync(guid);
            await _subTasks.DeleteAsync(toDelete);
        }

        public async Task<IEnumerable<SubTaskDto>> GetAllAsync()
        {
            var allNotes = await _subTasks.GetAllAsync();
            return _mapper.Map<IEnumerable<SubTaskDto>>(allNotes);
        }
        public async Task<SubTaskDto> GetByIDAsync(object id)
        {
            var subTask = await _subTasks.GetByIDAsync(id);
            // mam subtask
            //wygeneruj mu liste
            var list = await CreateListOfTasks(subTask.Id);
            // first map
            var subTaskDtoType = _mapper.Map<SubTaskDto>(subTask);
            //przypisz mu liste
            foreach (var item in list)
            {
                subTaskDtoType.IncludedTasks.Add(item);
            }
          //  subTaskDtoType.IncludedTasks = list.ToList();// #check
            //zwróc go z lista

            return subTaskDtoType;
        }

        public async Task UpdateAsync(UpdateSubTaskDto entityToUpdate)
        {
          //   var getSubTaskById = await _subTasks.GetByIDAsync(entityToUpdate.Id);
             
            var subTaskType = _mapper.Map<SubTask>(entityToUpdate);
            // set parent
          //  subTaskType.LevelAboveId = getSubTaskById.LevelAboveId;
            await _subTasks.UpdateAsync(subTaskType);
        }

        internal async Task<IEnumerable<SubTaskDto>> CreateListOfTasks(Guid parentId)
        {
            var list = await _subTasks.CreateListOfTasks(parentId);

            var mappedList =   _mapper.Map<IEnumerable<SubTaskDto>>(list);

            return mappedList;

        }
    }
}
