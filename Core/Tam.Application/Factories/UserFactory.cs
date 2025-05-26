using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.UserDtos;
using Tam.Application.Security;
using Tam.Domain.Entities;

namespace Tam.Application.Factories
{
    public static class UserFactory
    {
        public static User CreateFromRegisterDto(RegisterDto dto , IPasswordHasher hasher)
        {
            return new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                PasswordHash= hasher.Hash(dto.Password),
            };
        }
    }
}
