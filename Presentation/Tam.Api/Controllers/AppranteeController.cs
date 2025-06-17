using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.Aprantee;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppranteeController(IAppranteeService appranteeService) : ControllerBase
    {
        [HttpPost("create-apprantee")]
        public async Task<IActionResult> CreateApprantee([FromBody] CreateAppranteeDto dto)
        {
            var result = await appranteeService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }
        [HttpGet("get-active-apprantees")]
        public async Task<IActionResult> GetActiveApprantees()
        {
            var result = await appranteeService.GetAllActiveAsync();
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-passive-apprantees")]
        public async Task<IActionResult> GetPassiveApprantees()
        {
            var result = await appranteeService.GetAllPassiveAsync();
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await appranteeService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update-apprantee/{id}")]
        public async Task<IActionResult> UpdateApprantee(
            int id,
            [FromBody] UpdateAppranteeDto updateDto)
        {
            var result = await appranteeService.UpdateAsync(id, updateDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPatch("soft-delete-apprantee/{id}")]
        public async Task<IActionResult> SoftDeleteApprantee(int id)
        {
            var result = await appranteeService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
