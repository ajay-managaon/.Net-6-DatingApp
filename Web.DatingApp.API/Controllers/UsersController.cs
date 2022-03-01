using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Web.DatingApp.API.Web.DatingApp.Database;
using Web.DatingApp.API.Web.DatingApp.Dtos;
using Web.DatingApp.API.Web.DatingApp.Entities;
using Web.DatingApp.API.Web.DatingApp.Interfaces.Repositories;

namespace Web.DatingApp.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await userRepository.GetUsersAsync();
            var members = mapper.Map<IEnumerable<MemberDto>>(users);
            return Ok(members);
        }

        [HttpGet("user/{name}")]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUserByName(string name)
        {
            var user = await userRepository.GetUserByNameAsync(name);
            var member = mapper.Map<MemberDto>(user);
            if (member != null)
            {
                return Ok(member);
            }
            return NotFound("Member with id " + name + " not found");
        }

        [HttpPut("user/updateuser")]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await userRepository.GetUserByNameAsync(username);
            mapper.Map(memberUpdateDto, user);
            userRepository.Update(user);
            if (await userRepository.SaveAllChanges())
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
