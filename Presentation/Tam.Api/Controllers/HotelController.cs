using Microsoft.AspNetCore.Mvc;
using Tam.Application.Common.Wrappers;
using Tam.Application.Interfaces.Services;
using Tam.Application.Dtos.HotelDtos;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController(IHotelService hotelService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateHotelDto dto)
        {
            var result = await hotelService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await hotelService.GetAllAsync(page, pageSize);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await hotelService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHotelDto dto)
        {
            var result = await hotelService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await hotelService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPost("assign-facilities/{hotelId}")]
        public async Task<IActionResult> AssignFacilities(int hotelId, [FromBody] AssignFacilitiesDto dto)
        {
            var result = await hotelService.AssignFacilitiesAsync(hotelId, dto.FacilityIds);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("remove-facility/{hotelId}")]
        public async Task<IActionResult> RemoveFacility(int hotelId, [FromBody] RemoveFacilityDto dto)
        {
            var result = await hotelService.RemoveFacilityAsync(hotelId, dto.FacilityId);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }


        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var result = await hotelService.SearchAsync(term);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }
    }
}
