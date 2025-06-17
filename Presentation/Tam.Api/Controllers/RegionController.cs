using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.Region;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController(IRegionService regionService) : ControllerBase
    {
        [HttpPost("create-region")]
        public async Task<IActionResult> Create([FromBody] CreateRegionDto dto)
        {
            var result = await regionService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-all-region")]
        public async Task<IActionResult> GetAll()
        {
            var result = await regionService.GetAllAsync();
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-region-by-id{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await regionService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRegionDto dto)
        {
            var result = await regionService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await regionService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
