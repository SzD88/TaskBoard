using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Filters;
using WebApi.Helpers;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        private readonly IProjectService _projects;

        public ProjectsController(IProjectService service)
        {
            _projects = service;
        }
        [HttpPost] 
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Create new project")] //post=>/api/projects
        public async Task<ActionResult> AddProject(CreateProjectDto project)
        {
            var toShow = await _projects.CreateAsync(project); // null reference 
            return Created($"/api/projects/{toShow.Id}",toShow);
        }
         
        [HttpGet("{id}")]//get=>/api/projects/id
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves project by id")] 
        public async Task<ActionResult<ProjectDto>> GetProjectById(Guid id)
        {
            var toShow = await _projects.GetByIDAsync(id);
            return OkOrNotFound(toShow);
        }

        [HttpGet]//get=>/api/projects
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves all projects")] 
        public async Task<ActionResult<IReadOnlyList<ProjectDto>>> GetAll() //([FromQuery] SearchPackingLists query)
        {
            var toShow = await _projects.GetAllAsync();
            return OkOrNotFound(toShow);
        }
       
        [SwaggerOperation(Summary = "Update project")]
        [HttpPut]
        public async Task<IActionResult> UpdateProject(UpdateProjectDto projectToUpdate)
        {
            await _projects.UpdateAsync(projectToUpdate);
            return Ok();
        }
        [SwaggerOperation(Summary = "Delete project by id")]
        [HttpDelete]
        public async Task<IActionResult> DeleteProject(Guid id)
        {
            await _projects.DeleteAsync(id);
            return Ok($"Deleted task with id : {id} ");
        }
        [SwaggerOperation(Summary = "Delete all projects")]
        [HttpDelete("DeleteAll")]
        public async Task<IActionResult> DeleteAllProjects()
        {
            await _projects.DeleteAllProjectsAsync();
            return NoContent();
        }
        
    }
}
