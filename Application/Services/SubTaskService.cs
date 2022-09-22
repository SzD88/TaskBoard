using Application.Dto;
using Application.Interfaces;
using Application.Mappings;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services;

internal class SubTaskService : ISubTaskService
{
    private readonly ISubTaskRepository _subTasks;
    public SubTaskService(ISubTaskRepository subTasksRepository)
    {
        _subTasks = subTasksRepository;
    }
    public async Task<SubTaskDto> CreateAsync(CreateSubTaskDto subTask)
    {
        var asSubTaskType = Map.CreateSubTaskDtoToSubTask(subTask);
        var created = await _subTasks.CreateAsync(asSubTaskType);
        return Map.SubTaskToSubTaskDto(created);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _subTasks.DeleteAsync(id);
    }
    public async Task<IReadOnlyList<SubTaskDto>> GetAllAsync()
    {
        var allSubTasks = await _subTasks.GetAllAsync();

        var mappedSubTasks = Map.ListConvert(allSubTasks);

        foreach (var item in mappedSubTasks)
        {
           // var list = await _subTasks.CreateListOfTasks(item.Id);
          //  var mappedList = Map.ListConvert(list);

           // foreach (var lists in mappedList)
            {
          //      item.IncludedTasks.Add(lists);
            }
        }
        return mappedSubTasks;
    }
    public async Task<SubTaskDto> GetByIDAsync(Guid id)
    {
        var subTask = await _subTasks.GetByIDAsync(id); 
        var list = await CreateListOfTasksAsync(subTask.Id); 
        var subTaskDtoType = Map.SubTaskToSubTaskDto(subTask); 
        foreach (var item in list)
        {
            subTaskDtoType.IncludedTasks.Add(item);
        } 
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
        var subTaskType = Map.UpdateSubTaskDtoToSubTask(entityToUpdate); 
        await _subTasks.UpdateAsync(subTaskType);
    } 
    internal async Task<IReadOnlyList<SubTaskDto>> CreateListOfTasksAsync(Guid parentId)
    {
        var list = await _subTasks.CreateListOfTasks(parentId); 
        var mappedList = Map.ListConvert(list);  
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
