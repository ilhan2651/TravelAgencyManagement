using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RoleDtos;
using Tam.Application.Dtos.UserRole;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities.JoinTables;
using Tam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Tam.Infrastructure.Services
{
    public class RoleService(
      IRoleRepository roleRepository,
      IUserRepository userRepository,
      IUserRoleRepository userRoleRepository,
      IUnitOfWork unitOfWork,
      IMapper mapper) : IRoleService
    {
        public async Task<ServiceResult> CreateRoleAsync(CreateRoleDto dto)
        {
            var exists = await roleRepository.AnyAsync(r => r.Name == dto.Name);
            if (exists)
                return ServiceResult.Fail("Bu rol zaten mevcut.");

            var role = mapper.Map<Role>(dto);
            await roleRepository.AddAsync(role);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rol başarıyla eklendi.");
        }

        public async Task<ServiceResult> UpdateRoleAsync(int id, UpdateRoleDto dto)
        {
            var role = await roleRepository.GetByIdAsync(id);
            if (role == null)
                return ServiceResult.Fail("Rol bulunamadı.");

            role.Name = dto.Name;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rol güncellendi.");
        }

        public async Task<ServiceResult> DeleteRoleAsync(int id)
        {
            var role = await roleRepository.GetByIdAsync(id);
            if (role == null)
                return ServiceResult.Fail("Rol bulunamadı.");

            roleRepository.Delete(role);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rol silindi.");
        }

        public async Task<ServiceResult<List<RoleDto>>> GetAllRolesAsync()
        {
            var roles = await roleRepository.GetAll().ToListAsync();
            var dtoList = mapper.Map<List<RoleDto>>(roles);
            return ServiceResult<List<RoleDto>>.Ok(dtoList);
        }

        public async Task<ServiceResult> AssignRoleAsync(AssignUserRoleDto dto)
        {
            var user = await userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
                return ServiceResult.Fail("Kullanıcı bulunamadı.");

            var role = await roleRepository.GetByIdAsync(dto.RoleId);
            if (role == null)
                return ServiceResult.Fail("Rol bulunamadı.");

            var exists = await userRoleRepository.AnyAsync(x => x.UserId == dto.UserId && x.RoleId == dto.RoleId);
            if (exists)
                return ServiceResult.Fail("Rol zaten atanmış.");

            await userRoleRepository.AddAsync(new UserRole
            {
                UserId = dto.UserId,
                RoleId = dto.RoleId
            });

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rol başarıyla atandı.");
        }

        public async Task<ServiceResult> RemoveUserRoleAsync(AssignUserRoleDto dto)
        {
            var userRole = await userRoleRepository
                .FirstOrDefaultAsync(x => x.UserId == dto.UserId && x.RoleId == dto.RoleId);

            if (userRole == null)
                return ServiceResult.Fail("Atanmış böyle bir rol bulunamadı.");

            userRoleRepository.Delete(userRole);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rol kaldırıldı.");
        }

        public async Task<ServiceResult<List<UserRoleListDto>>> GetUserRolesAsync(int userId)
        {
            var userRoles = await userRoleRepository
                .Where(x => x.UserId == userId)
                .Include(x => x.Role)
                .ToListAsync();

            var dtoList = userRoles.Select(x => new UserRoleListDto
            {
                RoleId = x.RoleId,
                RoleName = x.Role.Name
            }).ToList();

            return ServiceResult<List<UserRoleListDto>>.Ok(dtoList);
        }

      
    }

}
