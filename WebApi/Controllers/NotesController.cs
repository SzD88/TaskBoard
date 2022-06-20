using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _notes;

        public NotesController(INoteService context)
        {
            _notes = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddNote(CreateNoteDto note)
        {
            var toShow = await _notes.Create(note);

            return Created($"api/Clients/{toShow.Id}", toShow.Id);

        }
    }
}
