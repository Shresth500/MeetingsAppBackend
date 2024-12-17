using MeetingsAPI.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MeetingsAPI.Models.Dto;
using MeetingsAPI.Models.Domain;

namespace MeetingsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<ApplicationUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        // POST: /api/Auth/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationDto registerRequestDto)
        {

            var identityUser = new ApplicationUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Email
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded)
            {
                        return Ok("User was registered! Please login.");
            }

            return BadRequest("Something went wrong: " + string.Join(", ", identityResult.Errors.Select(e => e.Description)));
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Email);

            if (user != null)
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult)
                {
                    // Get Roles for this user
                    //var roles = await userManager.GetRolesAsync(user);

                    //if (roles != null)
                    //{
                        // Create Token

                        var authToken = tokenRepository.CreateJWTToken(user);

                        var response = new LoginResponseDto
                        {
                            AuthToken = authToken,
                            Email = user.Email,
                            //Role = roles[0],
                            Message = "Successfully signed in",
                            Name = user.UserName
                        };

                        return Ok(response);
                    }
                }

            return BadRequest("Username or password incorrect");
        }
    }
}
