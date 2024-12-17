using MeetingsAPI.Models.Domain;
using MeetingsAPI.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpGet]
        [Route("User")]
        [Authorize]
        public async Task<IActionResult> getUsers()
        {
            var users = userManager.Users.Select(user => new UserDto
            {
                Id = user.Id,
                Name = user.UserName,
                Email = user.Email
            }).ToList();
            return Ok(users);
        }

    }
}
