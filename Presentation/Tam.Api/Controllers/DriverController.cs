using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.DriverDto;
using Tam.Application.Interfaces.Services;
using Tam.Infrastructure.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController(IDriverService driverService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateDriverDto dto)
        {
            var result = await driverService.CreateAsync(dto);
            if(!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Created(string.Empty, new { message = result.Message }); 
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await driverService.GetAllAsync(page, pageSize);
            if(!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await driverService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);

        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchAsync([FromQuery] string searchTerm)
        {
            var result = await driverService.SearchAsync(searchTerm);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
           return Ok(result.Data);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDeleteAsync(int id)
        {
            var result = await driverService.SoftDeleteDriverAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateDriverDto dto)
        {
            var result = await driverService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
    }
}
