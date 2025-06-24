using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.HotelReservationDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelReservationController(IHotelReservationService service) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateHotelReservationDto dto)
        {
            var result = await service.CreateAsync(dto);
            return result.IsSuccess
                ? Created(string.Empty, new { message = result.Message })
                : BadRequest(new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHotelReservationDto dto)
        {
            var result = await service.UpdateAsync(id, dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string name)
        {
            var result = await service.SearchByCustomerNameAsync(name);
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }

        [HttpGet("get-by-date-range")]
        public async Task<IActionResult> GetByDateRange([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var result = await service.GetByDateRangeAsync(start, end);
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }
    }
}
