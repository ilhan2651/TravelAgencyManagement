using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tam.Application.Dtos.CustomerDtos;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        [HttpPost("create-customer")]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerDto dto)
        {
            var result = await customerService.CreateCustomerAsync(dto);
                if (!result.IsSuccess)
                    return BadRequest(new { message = result.Message });
            return Created(string.Empty, new { message = result.Message });
        }
        [HttpGet("get-active-customers")]
        public async Task<IActionResult> GetActiveCustomers([FromQuery] int page=1 , [FromQuery] int pageSize= 10)
        {
            var result = await customerService.GetAllCustomersAsync(page, pageSize);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Ok(result.Data);
        }
        [HttpGet("search-customers")]
        public async Task<IActionResult> SearchCustomers(
            [FromQuery] string searchTerm,
            [FromQuery] int page=1,
            [FromQuery] int pageSize = 10)
        {
            var result = await customerService.SearchCustomerAsync(searchTerm,page,pageSize);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(result.Data);
        }
        [HttpPatch("soft-delete-customer/{id}")]
        public async Task<IActionResult> MarkedAsDeleted(int id )
        {
            var result = await customerService.SoftDeleteCustomerAsync(id);
            if(!result.IsSuccess)
                return BadRequest(new {message = result.Message});
            return Ok(new { message = result.Message });

        }
        [HttpPut("update-customer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id,[FromBody] UpdateCustomerDto updateDto)
        {
            var result = await customerService.UpdateCustomerAsync(id,updateDto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var result = await customerService.GetUserByIdAsync(id);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });
            return Ok(result.Data);

        }
    }
}
