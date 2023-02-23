using Application.Commands;
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{ 
    [Route("api/[controller]")]
    [ApiController]
    public class DaysController : BaseController
    {
        private readonly IDayService _projects;

        public DaysController(IDayService service)
        {
            _projects = service;
        }

        [HttpPost] 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Create new day")]  
        public async Task<ActionResult> AddProject(CreateDay project)
        {
            var toShow = await _projects.CreateAsync(project); 
            return Created($"/api/days/{toShow.Id}",toShow);
        }
         
        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves day by id")] 
        public async Task<ActionResult<DayDto>> GetProjectById(Guid id)
        {
            var toShow = await _projects.GetByIDAsync(id);
            return OkOrNotFound(toShow);
        }

        [HttpGet] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves all days")] 
        public async Task<ActionResult<IReadOnlyList<DayDto>>> GetAll() //([FromQuery] SearchPackingLists query)
        {
            var toShow = await _projects.GetAllAsync();
            return OkOrNotFound(toShow);
        }
        [HttpGet("weeksAhead/{weeksAhead}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves 7 days of week determined by number of weeks ahead")]
        public async Task<ActionResult<IReadOnlyList<DayDto>>> GetWeek(int weeksAhead) //([FromQuery] SearchPackingLists query)
        {
            var toShow = await _projects.GetWeek(weeksAhead);
            return OkOrNotFound(toShow);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [SwaggerOperation(Summary = "Update day")] 
        public async Task<ActionResult> UpdateProject(UpdateDayDto projectToUpdate)
        {
            await _projects.UpdateAsync(projectToUpdate);
            return NoContent(); 
        }

        [HttpDelete] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Delete day by id")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            await _projects.DeleteAsync(id);
            return NoContent();
        } 
    }
}
