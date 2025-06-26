using Microsoft.AspNetCore.Mvc;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RoleDtos;
using Tam.Application.Dtos.UserRole;
using Tam.Application.Interfaces.Services;

namespace Tam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController(IRoleService roleService) : ControllerBase
    {
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            var result = await roleService.CreateRoleAsync(dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : BadRequest(new { message = result.Message });
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto dto)
        {
            var result = await roleService.UpdateRoleAsync(id, dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await roleService.DeleteRoleAsync(id);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await roleService.GetAllRolesAsync();
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignUserRoleDto dto)
        {
            var result = await roleService.AssignRoleAsync(dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : BadRequest(new { message = result.Message });
        }

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveUserRole([FromBody] AssignUserRoleDto dto)
        {
            var result = await roleService.RemoveUserRoleAsync(dto);
            return result.IsSuccess
                ? Ok(new { message = result.Message })
                : NotFound(new { message = result.Message });
        }

        [HttpGet("user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var result = await roleService.GetUserRolesAsync(userId);
            return result.IsSuccess
                ? Ok(result.Data)
                : NotFound(new { message = result.Message });
        }
    }
}
