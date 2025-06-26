using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RoleDtos;
using Tam.Application.Dtos.UserRole;

namespace Tam.Application.Interfaces.Services
{
    public interface IRoleService
    {
        Task<ServiceResult> AssignRoleAsync(AssignUserRoleDto dto);
        Task<ServiceResult<List<UserRoleListDto>>> GetUserRolesAsync(int userId);
        Task<ServiceResult> RemoveUserRoleAsync(AssignUserRoleDto dto);
        Task<ServiceResult> CreateRoleAsync(CreateRoleDto dto);
        Task<ServiceResult> UpdateRoleAsync(int id, UpdateRoleDto dto);
        Task<ServiceResult> DeleteRoleAsync(int id);
        Task<ServiceResult<List<RoleDto>>> GetAllRolesAsync();

    }
}
