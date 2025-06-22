using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.PaymentMethodDtos;
using Tam.Application.Interfaces.Services;
using Tam.Application.Common.Wrappers;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController(IPaymentMethodService paymentMethodService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreatePaymentMethodDto dto)
        {
            var result = await paymentMethodService.CreateMethod(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await paymentMethodService.GetAllMethods();
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await paymentMethodService.GetMethodById(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePaymentMethodDto dto)
        {
            var result = await paymentMethodService.UpdateMethod(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await paymentMethodService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
