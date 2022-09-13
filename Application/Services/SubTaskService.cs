﻿using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

internal class SubTaskService : ISubTaskService
  {
      private readonly ISubTaskRepository _subTasks;
      private readonly IMapper _mapper;
      public SubTaskService(ISubTaskRepository subTasksRepository, IMapper mapper) //  IMapper mapper
      {
          _subTasks = subTasksRepository;
          _mapper = mapper;
      }

      public async Task<SubTaskDto> CreateAsync(CreateSubTaskDto subTask)
      {
          var asSubTaskType = _mapper.Map<SubTask>(subTask);
          var created = await _subTasks.CreateAsync(asSubTaskType);
          return _mapper.Map<SubTaskDto>(created);
      } 
      public async Task DeleteAsync(Guid id)
      { 
          await _subTasks.DeleteAsync(id);
      }

      public async Task<IReadOnlyList<SubTaskDto>> GetAllAsync()
      {
          var allSubTasks = await _subTasks.GetAllAsync();

          var mappedSubTasks = _mapper.Map<IReadOnlyList<SubTaskDto>>(allSubTasks);

          foreach (var item in mappedSubTasks)
          {
              var list = await _subTasks.CreateListOfTasks(item.Id);
              var mappedList = _mapper.Map<IReadOnlyList<SubTaskDto>>(list);

              foreach (var lists in mappedList)
              {
                  item.IncludedTasks.Add(lists);
              }
          }
          return mappedSubTasks;
      }
      public async Task<SubTaskDto> GetByIDAsync(Guid id)
      {
          var subTask = await _subTasks.GetByIDAsync(id);
          // mam subtask
          //wygeneruj mu liste
          var list = await CreateListOfTasksAsync(subTask.Id);
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
     
      public async Task<bool> ChangeCompletedStateAsync(Guid id) //#refactor
      { 
          var subTask = await _subTasks.GetByIDAsync(id);

          if (subTask.GetCompleted() == true) 
              subTask.EditCompleted(false); 
          else 
              subTask.EditCompleted(true); 
           
         await _subTasks.UpdateAsync(subTask);

          return subTask.GetCompleted();
      }
      public async Task UpdateAsync(UpdateSubTaskDto entityToUpdate)
      {
          //   var getSubTaskById = await _subTasks.GetByIDAsync(entityToUpdate.Id);

          var subTaskType = _mapper.Map<SubTask>(entityToUpdate);
          // set parent
          //  subTaskType.LevelAboveId = getSubTaskById.LevelAboveId;
          await _subTasks.UpdateAsync(subTaskType);
      }

      internal async Task<IReadOnlyList<SubTaskDto>> CreateListOfTasksAsync(Guid parentId)
      {
          var list = await _subTasks.CreateListOfTasks(parentId);

          var mappedList = _mapper.Map<IReadOnlyList<SubTaskDto>>(list);

          return mappedList;

      }

      public async Task DeleteAllSubTasksAsync()
      {
          var allSubTasks = await _subTasks.GetAllAsync();

          foreach (var subTask in allSubTasks)
          {
              await _subTasks.DeleteAsync(subTask.Id);
          }
      }

   
}
