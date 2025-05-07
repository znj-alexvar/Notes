using Microsoft.AspNetCore.Mvc;
using NotesServer;
using NotesServer.Models;
using Notes.Models;
using Microsoft.EntityFrameworkCore;

namespace User.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly NotesDbContext dbContext;

        public UserController(NotesDbContext dbContext) { 

            this.dbContext = dbContext;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {
            List<UserEntity> users = await dbContext.Users.ToListAsync();
            List<GetUserDTO> request = new List<GetUserDTO>();
            foreach (UserEntity user in users) {
                request.Add(new GetUserDTO(user.Id, user.login));
            }
            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(AddUserDTO request) 
        {
            await dbContext.Users.AddAsync(new UserEntity(request.login, request.password));
            await dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
