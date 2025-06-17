using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.LocationDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController(ILocationService locationService) : ControllerBase
    {
        [HttpPost("create-location")]
        public async Task<IActionResult> Create([FromBody] CreateLocationDto dto)
        {
            var result = await locationService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-all-location")]
        public async Task<IActionResult> GetAll()
        {
            var result = await locationService.GetAllAsync();
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-location-by-id{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await locationService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLocationDto dto)
        {
            var result = await locationService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await locationService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
