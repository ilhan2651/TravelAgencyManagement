using Microsoft.AspNetCore.Mvc;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.CommonDtos;
using Tam.Application.Dtos.Transfer;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController(ITransferService transferService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateTransferDto dto)
        {
            var result = await transferService.CreateAsync(dto);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Created(string.Empty, new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateTransferDto dto)
        {
            var result = await transferService.UpdateAsync(id, dto);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> SoftDelete(int id)
        {
            var result = await transferService.SoftDeleteAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10)
        {
            var result = await transferService.GetAllAsync(page, pageSize);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await transferService.GetByIdAsync(id);
            if (!result.IsSuccess)
                return NotFound(new { message = result.Message });

            return Ok(result.Data);
        }

        [HttpPost("assign-drivers/{transferId}")]
        public async Task<IActionResult> AssignDrivers(int transferId, [FromBody] AssignIdsDto dto)
        {
            var result = await transferService.AssignDriversAsync(transferId, dto.Ids);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpPost("assign-vehicles/{transferId}")]
        public async Task<IActionResult> AssignVehicles(int transferId, [FromBody] AssignIdsDto dto)
        {
            var result = await transferService.AssignVehiclesAsync(transferId, dto.Ids);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("remove-driver/{transferId}/{driverId}")]
        public async Task<IActionResult> RemoveDriver(int transferId, int driverId)
        {
            var result = await transferService.RemoveDriverAsync(transferId, driverId);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

        [HttpDelete("remove-vehicle/{transferId}/{vehicleId}")]
        public async Task<IActionResult> RemoveVehicle(int transferId, int vehicleId)
        {
            var result = await transferService.RemoveVehicleAsync(transferId, vehicleId);
            if (!result.IsSuccess)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
