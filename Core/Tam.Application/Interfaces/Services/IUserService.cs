using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Auth;
using Tam.Application.Dtos.UserDtos;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<ServiceResult> RegisterAsync(RegisterDto register);
        Task<ServiceResult<AuthResponseDto>> LoginAsync(LoginDto login);
        Task<ServiceResult> SoftDeleteUserAsync(int userId);
        Task<ServiceResult> UpdateUserAsync(int userId, UpdateUserDto updateUserDto);
        Task<ServiceResult<UserListDto>> GetUserByIdAsync(int userId);
        Task<ServiceResult<List<UserListDto>>> GetAllActiveAsync();
        Task<ServiceResult<List<UserDeletedListDto>>> GetAllDeletedAsync();

        Task<ServiceResult<AuthResponseDto>> RefreshTokenAsync(string refreshToken);



    }
}
