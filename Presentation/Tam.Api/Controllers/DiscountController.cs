using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.DiscountDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController(IDiscountService service) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateDiscountDto dto)
        {
            var result = await service.CreateAsync(dto);
            return result.IsSuccess ? Ok(new { message = result.Message }) : BadRequest(new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDiscountDto dto)
        {
            var result = await service.UpdateAsync(id, dto);
            return result.IsSuccess ? Ok(new { message = result.Message }) : NotFound(new { message = result.Message });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await service.DeleteAsync(id);
            return result.IsSuccess ? Ok(new { message = result.Message }) : NotFound(new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await service.GetAllAsync();
            return result.IsSuccess ? Ok(result.Data) : NotFound(new { message = result.Message });
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await service.GetByIdAsync(id);
            return result.IsSuccess ? Ok(result.Data) : NotFound(new { message = result.Message });
        }
    }

}
