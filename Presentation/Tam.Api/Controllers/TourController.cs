using Microsoft.AspNetCore.Mvc;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.CommonDtos;
using Tam.Application.Dtos.TourDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourController(ITourService tourService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTourDto dto)
        {
            var result = await tourService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Created(string.Empty, new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTourDto dto)
        {
            var result = await tourService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await tourService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await tourService.GetAllAsync(page, pageSize);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await tourService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var result = await tourService.SearchAsync(term);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }

        [HttpPost("assign-drivers/{tourId}")]
        public async Task<IActionResult> AssignDrivers(int tourId, [FromBody] AssignIdsDto dto)
        {
            var result = await tourService.AssignDriversAsync(tourId, dto.Ids);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpPost("assign-vehicles/{tourId}")]
        public async Task<IActionResult> AssignVehicles(int tourId, [FromBody] AssignIdsDto dto)
        {
            var result = await tourService.AssignVehiclesAsync(tourId, dto.Ids);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpPost("assign-hotels/{tourId}")]
        public async Task<IActionResult> AssignHotels(int tourId, [FromBody] AssignIdsDto dto)
        {
            var result = await tourService.AssignHotelsAsync(tourId, dto.Ids);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpPost("assign-regions/{tourId}")]
        public async Task<IActionResult> AssignRegions(int tourId, [FromBody] AssignIdsDto dto)
        {
            var result = await tourService.AssignRegionsAsync(tourId, dto.Ids);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-driver/{tourId}/{driverId}")]
        public async Task<IActionResult> RemoveDriver(int tourId, int driverId)
        {
            var result = await tourService.RemoveDriverAsync(tourId, driverId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-vehicle/{tourId}/{vehicleId}")]
        public async Task<IActionResult> RemoveVehicle(int tourId, int vehicleId)
        {
            var result = await tourService.RemoveVehicleAsync(tourId, vehicleId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-hotel/{tourId}/{hotelId}")]
        public async Task<IActionResult> RemoveHotel(int tourId, int hotelId)
        {
            var result = await tourService.RemoveHotelAsync(tourId, hotelId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpDelete("remove-region/{tourId}/{regionId}")]
        public async Task<IActionResult> RemoveRegion(int tourId, int regionId)
        {
            var result = await tourService.RemoveRegionAsync(tourId, regionId);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }
    }
}