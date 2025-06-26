using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Services
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user, List<string> roles);
        string GenerateRefreshToken();
    }
}
