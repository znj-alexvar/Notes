using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesServer;
using NotesServer.Models;
using Notes.Models;
using Microsoft.EntityFrameworkCore;
using Notes_ihopethenormalone_.Models;

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {

        private readonly NotesDbContext dbContext;

        public NotesController(NotesDbContext dbContext) {

            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetNotes([FromQuery] string userid) {
            List<NoteEntity> notes = await dbContext.Notes.Where(c => c.UserId == Guid.Parse(userid) /*&& !(c.deleted)*/).ToListAsync();
            List<NoteEntityForFront> frontnotes = new List<NoteEntityForFront>();
            foreach (NoteEntity note in notes) {
                NoteEntityForFront frontnote = new NoteEntityForFront();
                frontnote.Id = note.Id;
                frontnote.Name = note.Name;
                frontnote.Text = note.Text;
                frontnote.UserId = note.UserId;
                frontnotes.Add(frontnote);
            }
            return Ok(frontnotes);
        }


        /*public IActionResult GetAllNotes()
        {
            var notes = dbContext.Notes.ToList();
            return Ok(notes);
        }*/

        [HttpPost]
        public async Task<IActionResult> AddNote(AddRequestDTO request) {
            NoteEntity domainModelNote = new NoteEntity(request.Name, request.Text, Guid.Parse(request.UserId));

            await dbContext.AddAsync(domainModelNote);
            await dbContext.SaveChangesAsync();

            return Ok(domainModelNote);
        }

        [HttpPut]
        public async Task<IActionResult> SaveChanges(SaveRequestDTO request) {
            NoteEntity note = await dbContext.Notes.FindAsync(Guid.Parse(request.Id));
            note.Name = request.Name;
            note.Text = request.Text;
            dbContext.Update(note);
            await dbContext.SaveChangesAsync();
            return Ok(note);
        }

        /*public IActionResult Put(NoteEntity note) {
            if (ModelState.IsValid) {
                dbContext.Update(note);
                dbContext.SaveChanges();
                return Ok(note);
            }
            return BadRequest(ModelState);
        }*/

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string id) {
            NoteEntity note = await dbContext.Notes.FindAsync(Guid.Parse(id));
            if (note != null) {
                dbContext.Notes.Remove(note);
                dbContext.SaveChangesAsync();
            }

            return Ok(note);
        }
    }
}
