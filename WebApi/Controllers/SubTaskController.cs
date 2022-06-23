using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly INoteService _notes;

        public SubTaskController(INoteService context)
        {
            _notes = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(CreateSubTaskDto note)
        {
            var toShow = await _notes.CreateAsync(note);

            return Created($"api/Clients/{toShow.Id}", toShow.Id);

        }
    }
}
