using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetworkBackendV2.Application.DTOs_and_Response_Models;
using SocialNetworkBackendV2.Application.Interfaces;
using SocialNetworkBackendV2.Domain.Entities;

namespace SocialNetworkBackendV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto user)
        {    
            var result = await _userService.RegisterUserAsync(user);

            if (!result.Success) 
                return BadRequest(result.Message); 
            
            return Ok(result.Message);
        }
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var result = await _userService.LoginUserAsync(userLoginDto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.User);
        }
    }
}
