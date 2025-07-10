using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.TourReservationDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourReservationController(ITourReservationService tourReservationService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTourReservationDto dto)
        {
            var result = await tourReservationService.CreateAsync(dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : BadRequest(new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTourReservationDto dto)
        {
            var result = await tourReservationService.UpdateAsync(id, dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await tourReservationService.DeleteAsync(id);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await tourReservationService.GetAllAsync();
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await tourReservationService.GetByIdAsync(id);
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string term)
        {
            var result = await tourReservationService.Search(term);
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }
    }
}