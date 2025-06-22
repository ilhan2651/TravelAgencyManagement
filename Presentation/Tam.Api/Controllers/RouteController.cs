using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.RouteDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouteController(IRouteService routeService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRouteDto createDto)
        {
            var result = await routeService.CreateAsync(createDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Created(string.Empty, new { message = result.Message });
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await routeService.GetAllAsync();
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await routeService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(result.Data);
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRouteDto updateDto)
        {
            var result = await routeService.UpdateAsync(id, updateDto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await routeService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });
            return Ok(new { message = result.Message });
        }

    }
}
