using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.UserDtos;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IUserService
    {
        Task<ServiceResult> RegisterAsync(RegisterDto register);
        
    }
}
