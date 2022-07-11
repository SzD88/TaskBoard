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

        public SubTaskController(ISubTaskService context)
        {
            _subTasks = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddSubTask(CreateSubTaskDto subTask)
        {
            var toShow = await _subTasks.CreateAsync(subTask);

            return Created($"api/Clients/{toShow.Id}", toShow.Id); 
        }

        [SwaggerOperation(Summary = "Retrieves task by Id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSubTaskById(Guid id)
        {

            var toShow = await _subTasks.GetByIDAsync(id);

            return Ok(toShow.Content);
        }

        [SwaggerOperation(Summary = "Retrieves all tasks")]
        [HttpGet]
        public async Task<IActionResult> GetAll( )
        {

            var toShow = await _subTasks.GetAllAsync();

            return Ok(toShow);
        }
    }
}
