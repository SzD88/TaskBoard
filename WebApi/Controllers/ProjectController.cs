using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly INoteService _notes;

        public ProjectController(INoteService context)
        {
            _notes = context;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddProject(CreateProjectDto project)
        //{
        //    var toShow = await _notes.AddNote(note);


        //    return Created($"api/Clients/{toShow.Id}", note);

        //}
    }
}
