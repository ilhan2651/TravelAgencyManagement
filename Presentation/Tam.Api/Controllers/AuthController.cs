using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tam.Application.Dtos.UserDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService userService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await userService.LoginAsync(loginDto);
            if (!result.IsSuccess)
                return Unauthorized(new { message = result.Message });

            Response.Cookies.Append("refreshToken", result.Data.RefreshToken, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = result.Data.Expiration.AddDays(5) 
            });

            return Ok(result.Data);

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var result = await userService.RegisterAsync(registerDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Created("", new { message = result.Message });
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
                return Unauthorized(new { message = "Refresh token bulunamadı." });

            var result = await userService.RefreshTokenAsync(refreshToken);
            if (!result.IsSuccess)
                return Unauthorized(new { message = result.Message });

            return Ok(result.Data);
        }
        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> Me()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if(userIdClaim is null)
                return Unauthorized();

            var userId = int.Parse(userIdClaim);
            var result = await userService.GetUserByIdAsync(userId);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }
    }

}
