using Application.Commands;
using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        [SwaggerOperation(Summary = "Create new project")]  
        public async Task<ActionResult> AddProject(CreateProject project)
        {
            var toShow = await _projects.CreateAsync(project); 
            return Created($"/api/projects/{toShow.Id}",toShow);
        }
         
        [HttpGet("{id}")] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves project by id")] 
        public async Task<ActionResult<ProjectDto>> GetProjectById(Guid id)
        {
            var toShow = await _projects.GetByIDAsync(id);
            return OkOrNotFound(toShow);
        }

        [HttpGet] 
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(Summary = "Retrieves all projects")] 
        public async Task<ActionResult<IReadOnlyList<ProjectDto>>> GetAll() //([FromQuery] SearchPackingLists query)
        {
            var toShow = await _projects.GetAllAsync();
            return OkOrNotFound(toShow);
        }
       
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)] 
        [SwaggerOperation(Summary = "Update project")] 
        public async Task<ActionResult> UpdateProject(UpdateProjectDto projectToUpdate)
        {
            await _projects.UpdateAsync(projectToUpdate);
            return NoContent(); 
        }

        [HttpDelete] 
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [SwaggerOperation(Summary = "Delete project by id")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            await _projects.DeleteAsync(id);
            return NoContent();
        } 
    }
}
