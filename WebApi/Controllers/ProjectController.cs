using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebApi.Filters;
using WebApi.Helpers;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projects;

        public ProjectController(IProjectService service)
        {
            _projects = service;
        }

        [SwaggerOperation(Summary = "Create new project")] //post=>/api/project/
        [HttpPost]
        public async Task<IActionResult> AddProject(CreateProjectDto project)
        {
            var toShow = await _projects.CreateAsync(project);
            return Created($"api/Clients/{toShow.Id}", "Created, new id is : " + toShow.Id);
        }

        [SwaggerOperation(Summary = "Retrieves project by id")] 
        //get=>/api/project/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            var toShow = await _projects.GetByIDAsync(id);
            return Ok(toShow);
        }
        [SwaggerOperation(Summary = "Retrieves all projects")]//get=>/api/project/
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var toShow = await _projects.GetAllAsync();
            return Ok(toShow);
        }
        [SwaggerOperation(Summary = "Retrieves all projects sorted by property")]
        //get=>/api/Project/Sort?SortField=title&Ascending=true'
        [HttpGet("Sort")]
        public async Task<IActionResult> GetAllSorted([FromQuery] SortingFilter sortingFilter)
        {

            var validSortingFilter = new SortingFilter(sortingFilter.SortField, sortingFilter.Ascending);

            var toShow = await _projects.GetAllSortedAsync(validSortingFilter.SortField, validSortingFilter.Ascending);
            return Ok(toShow);
        }

        [SwaggerOperation(Summary = "Retrieves sort fields")]
        //get=>/api/Project/sort/sortfields
        [HttpGet("sort/sortfields")] // ???????????get?
        public IActionResult GetSortFields()
        {
            return Ok(SortingHelper.GetSortFields().Select(x => x.Key));
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
