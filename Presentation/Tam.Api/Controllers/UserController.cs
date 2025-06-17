using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.UserDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await userService.RegisterAsync(registerDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Created("", new { message = result.Message });
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await userService.GetUserByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }
        [HttpPatch("soft-delete/{id}")]
        public async Task<IActionResult> MarkedAsDeleted(int id)
        {
            var result = await userService.SoftDeleteUserAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await userService.LoginAsync(loginDto);
            if(!result.IsSuccess)
                return Unauthorized(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateUserDto updateDto)
        {
            var result = await userService.UpdateUserAsync(id, updateDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Ok(new { message = result.Message });

        }
        [HttpGet("get-all-passive")]
        public async Task<IActionResult> GetAllPassiveUsers()
        {
            var result = await userService.GetAllDeletedAsync();
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }
        [HttpGet("get-all-active")]
        public async Task<IActionResult> GetAllActiveUsers()
        {
            var result = await userService.GetAllActiveAsync();
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }
        
    }
}
