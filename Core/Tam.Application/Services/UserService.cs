using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.UserDtos;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Security;

namespace Tam.Application.Services
{
    public class UserService(IUserRepository userRepository,IPasswordHasher passwordHasher) : IUserService
    {
        public async Task<ServiceResult> RegisterAsync(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
                return ServiceResult.Fail("Şifreler eşleşmiyor. Lütfen tekrar deneyin.");
            var user = UserFactory.CreateFromRegisterDto(registerDto,passwordHasher);
            await userRepository.AddAsync(user);


        }
       
    }
}
