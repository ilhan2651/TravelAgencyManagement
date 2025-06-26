using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.UserDtos;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Security;
using AutoMapper;
using Tam.Domain.Entities;
using Tam.Application.Interfaces.Services;
using Tam.Infrastructure.Services;
using Tam.Application.Dtos.Auth;

namespace Tam.Application.Services
{
    public class UserService(IUserRepository userRepository
        ,IPasswordHasher passwordHasher
        , IUnitOfWork unitOfWork
        , IMapper mapper
        ,ITokenService tokenService
        , IRoleService roleService) : IUserService
    {
        public async Task<ServiceResult> SoftDeleteUserAsync(int userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
                return ServiceResult.Fail("Kullanıcı bulunamadı.");
            if (user.DeletedAt != null)
                return ServiceResult.Fail("Kullanıcı zaten silinmiş.");
            user.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Kullanıcı başarıyla silindi.");
        }

       

        public async Task<ServiceResult<UserListDto>> GetUserByIdAsync(int userId)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
                return ServiceResult<UserListDto>.Fail("Kullanıcı bulunamadı.");
           var result= mapper.Map<UserListDto>(user);
            return ServiceResult<UserListDto>.Ok(result);

        }

        public async Task<ServiceResult> LoginAsync(LoginDto login)
        {
            var user = await userRepository.GetByEmailAsync(login.Email);
            if (user == null)
                return ServiceResult.Fail("Kullanıcı bulunamadı. Lütfen kayıt olun veya bilgilerinizi kontrol edin.");
            if (!passwordHasher.Verify(login.Password, user.PasswordHash))
                return ServiceResult.Fail("Şifre yanlış. Lütfen tekrar deneyin.");
            var result = await roleService.GetUserRolesAsync(user.Id);
            if (!result.IsSuccess || result.Data is null)
                return ServiceResult.Fail("Kullanıcının rolleri alınamadı.");

            var roleNames = result.Data.Select(r => r.RoleName).ToList();  
            var token = tokenService.GenerateJwtToken(user,roleNames);
            var refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken=refreshToken;
            user.RefreshTokenExpiry=DateTime.UtcNow.AddDays(5);
            userRepository.Update(user);
            await unitOfWork.SaveChangesAsync();

            var response = new AuthResponseDto
            {
                Token = token,
                RefreshToken = refreshToken,
                Expiration = DateTime.UtcNow.AddHours(1),
                Email = user.Email,
                Roles = roleNames,
            };
            return ServiceResult<AuthResponseDto>.Ok(response,"Giriş Yapıldı");
        }

        public async Task<ServiceResult> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
                return ServiceResult.Fail("Şifreler eşleşmiyor. Lütfen tekrar deneyin.");
            var user = UserFactory.CreateFromRegisterDto(registerDto,passwordHasher);
            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Kayıt başarılı.");
        }

        public async Task<ServiceResult> UpdateUserAsync(int userId, UpdateUserDto updateUserDto)
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
                return ServiceResult.Fail("Kullanıcı bulunamadı.");

            mapper.Map(updateUserDto, user); 

            user.UpdatedAt = DateTime.UtcNow;

             userRepository.Update(user);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Kullanıcı başarıyla güncellendi.");
        }

        public async Task<ServiceResult<List<UserListDto>>> GetAllActiveAsync()
        {
            var users = await userRepository.GetActiveUsers();
            if (users == null || !users.Any())
                return ServiceResult<List<UserListDto>>.Fail("Aktif kullanıcı bulunamadı.");
            var result=mapper.Map<List<UserListDto>>(users);
            return ServiceResult<List<UserListDto>>.Ok(result);
        }

        public async Task<ServiceResult<List<UserDeletedListDto>>> GetAllDeletedAsync()
        {
            var users = await userRepository.GetPassiveUsers();
            var result = mapper.Map<List<UserDeletedListDto>>(users ?? new List<User>());
            return ServiceResult<List<UserDeletedListDto>>.Ok(result);

        }
    }
}
