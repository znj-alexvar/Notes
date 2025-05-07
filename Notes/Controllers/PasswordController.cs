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

    public class PasswordController : ControllerBase
    {
        private readonly NotesDbContext dbContext;

        public PasswordController(NotesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] string id, string password) {
            UserEntity user = await dbContext.Users.FindAsync(Guid.Parse(id));
            bool pass = (user.password == password);
            return Ok(pass);
        }
    }
}
