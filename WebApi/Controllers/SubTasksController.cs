using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTasksController : BaseController
    {
        private readonly ISubTaskService _subTasks;

        public SubTasksController(ISubTaskService service)
        {
            _subTasks = service;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Create new task")] 
        public async Task<ActionResult> AddSubTask(CreateSubTaskDto subTask)
        {
            var toShow = await _subTasks.CreateAsync(subTask); 
            return Created($"api/subtask/{toShow.Id}", toShow); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves task by id")] 
        public async Task<ActionResult<SubTaskDto>> GetSubTaskById(Guid id)
        { 
            var toShow = await _subTasks.GetByIDAsync(id); 
            return OkOrNotFound(toShow);
        } 

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves all tasks")] 
        public async Task<ActionResult<IReadOnlyList<SubTaskDto>>>  GetAll()
        { 
            var toShow = await _subTasks.GetAllAsync(); 
            return OkOrNotFound(toShow);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Update task")] 
        public async Task<ActionResult> UpdateTask(UpdateSubTaskDto newSubTask)
        {
            await _subTasks.UpdateAsync(newSubTask);
            return NoContent(); 
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Delete task by id")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            await _subTasks.DeleteAsync(id);
            return NoContent(); 
        }
    }
}
