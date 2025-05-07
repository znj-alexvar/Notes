using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesServer;
using NotesServer.Models;
using Notes.Models;
using Microsoft.EntityFrameworkCore;
using Notes_ihopethenormalone_.Models;

namespace Note.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController: ControllerBase
    {
        private readonly NotesDbContext dbContext;

        public NoteController(NotesDbContext dbContext)
        {

            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetNote([FromQuery] string noteid)
        {
            List<NoteEntity> notes = await dbContext.Notes.ToListAsync();
            NoteEntityForFront frontnote = new NoteEntityForFront();
            foreach (NoteEntity note in notes)
            {
                if (Guid.Parse(noteid) == note.Id)
                {
                    frontnote.Id = note.Id;
                    frontnote.Name = note.Name;
                    frontnote.Text = note.Text;
                    frontnote.UserId = note.UserId;
                    break;
                }
            }
            return Ok(frontnote);
        }
    }
}
