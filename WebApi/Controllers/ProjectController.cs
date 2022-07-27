using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers
{  
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projects;

        public ProjectController(IProjectService context)
        {
            _projects = context;
        }

        [SwaggerOperation(Summary = "Create new project")]
        [HttpPost]
        public async Task<IActionResult> AddProject(CreateProjectDto project)
        {
            var toShow = await _projects.CreateAsync(project);
            return Created($"api/Clients/{toShow.Id}", "Created, new id is : " + toShow.Id);
        }

        [SwaggerOperation(Summary = "Retrieves project by id")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var toShow = await _projects.GetByIDAsync(id);
            return Ok(toShow);
        }

        [SwaggerOperation(Summary = "Retrieves all projects")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toShow = await _projects.GetAllAsync();
            return Ok(toShow);
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
        public async Task<IActionResult> DeleteAllProjects( )
        {
            await _projects.DeleteAllProjects();
            return NoContent();
        }
    }
}
