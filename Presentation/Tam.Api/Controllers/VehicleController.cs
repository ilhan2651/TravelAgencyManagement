using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.VehicleDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(IVehicleService vehicleService) : ControllerBase
    {
        [HttpPost("create-vehicle")]
        public async Task<IActionResult> Create([FromBody] CreateVehicleDto dto)
        {
            var result = await vehicleService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-all-vehicle")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await vehicleService.GetAllAsync(page, pageSize);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-vehicle-by-id{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await vehicleService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var result = await vehicleService.SearchAsync(term);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await vehicleService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateVehicleDto dto)
        {
            var result = await vehicleService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
