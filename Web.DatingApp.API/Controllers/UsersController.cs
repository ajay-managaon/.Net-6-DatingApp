using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.DatingApp.API.Web.DatingApp.Database;
using Web.DatingApp.API.Web.DatingApp.Entities;

namespace Web.DatingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DatingAppDbContext datingAppDbContext;

        public UsersController(DatingAppDbContext datingAppDbContext)
        {
            this.datingAppDbContext = datingAppDbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await datingAppDbContext.tbl_User.ToListAsync();
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(int id)
        {
            var user = await datingAppDbContext.tbl_User.FindAsync(id);
            if (user!= null)
            {
                return Ok(user);
            }
            return NotFound("User with id " + id + " not found");
        }
    }
}
