using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly ISubTaskService _subTasks;

        public SubTaskController(ISubTaskService service)
        {
            _subTasks = service;
        }
        [SwaggerOperation(Summary = "Create new task")] 
        [HttpPost]
        public async Task<IActionResult> AddSubTask(CreateSubTaskDto subTask)
        {
            var toShow = await _subTasks.CreateAsync(subTask); 
            return Created($"api/subtask/{toShow.Id}", toShow.Id); 
        }

        [SwaggerOperation(Summary = "Retrieves task by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubTaskById(Guid id)
        { 
            var toShow = await _subTasks.GetByIDAsync(id); 
            return Ok(toShow);
        }
        [SwaggerOperation(Summary = "Change SubTask completed state")]
        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeCompletedState(Guid id)
        {
            var answer =   await _subTasks.ChangeCompletedStateAsync(id); 
            return Ok("state changed to: "+ answer);
        }

        [SwaggerOperation(Summary = "Retrieves all tasks")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        { 
            var toShow = await _subTasks.GetAllAsync(); 
            return Ok(toShow);
        }
        // change by content and id
        [SwaggerOperation(Summary = "Update task")]
        [HttpPut]
        public async Task<IActionResult> UpdateTask(UpdateSubTaskDto newSubTask)
        {
            await _subTasks.UpdateAsync(newSubTask);
            return Ok();
        }
        //delete by id
        [SwaggerOperation(Summary = "Delete task by id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _subTasks.DeleteAsync(id);
            return Ok($"Deleted task with id : {id} ");
        }
        [SwaggerOperation(Summary = "Delete all subTasks")]
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAllProjects()
        {
            await _subTasks.DeleteAllSubTasksAsync();
            return NoContent();
        }
    }
}
