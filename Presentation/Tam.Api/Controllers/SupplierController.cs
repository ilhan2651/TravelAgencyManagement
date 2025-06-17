using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.Supplier;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController(ISupplierService supplierService) : ControllerBase
    {
        [HttpPost("create-supplier")]
        public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplierDto dto)
        {
            var result = await supplierService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpGet("get-suppliers")]
        public async Task<IActionResult> GetSuppliers()
        {
            var result = await supplierService.GetAllSuppliers();
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data); 
        }

        [HttpGet("search-suppliers")]
        public async Task<IActionResult> SearchSuppliers([FromQuery] string term)
        {
            var result = await supplierService.SearchSupplierAsync(term);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await supplierService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPut("update-supplier/{id}")]
        public async Task<IActionResult> UpdateSupplier(
            int id,
            [FromBody] UpdateSupplierDto updateDto)
        {
            var result = await supplierService.UpdateAsync(id, updateDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPatch("soft-delete-supplier/{id}")]
        public async Task<IActionResult> SoftDeleteSupplier(int id)
        {
            var result = await supplierService.SoftDeleteSupplierAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
