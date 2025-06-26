using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class UserRepository(TamDbContext context) : GenericRepository<User>(context), IUserRepository
    {
        public async Task<List<User>> GetActiveUsers()
        {
            return await context.Users
                 .Where(u => u.DeletedAt == null)
                 .OrderByDescending(u => u.CreatedAt)
                 .ToListAsync();

        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await context.Users
                .FirstOrDefaultAsync(u=>u.Email==email);
        }

        public async Task<List<User>> GetPassiveUsers()
        {
            return await context.Users
                .Where(u=> u.DeletedAt != null)
                .OrderByDescending(u => u.DeletedAt)
                .ToListAsync();
        }
        public async Task<User?> GetByRefreshTokenAsync(string refreshToken)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken && u.DeletedAt == null);
        }

    }
}
