using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities.JoinTables;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class UserRoleRepository(TamDbContext context) : GenericRepository<UserRole>(context), IUserRoleRepository
    {
        public async Task<UserRole?> FirstOrDefaultAsync(Expression<Func<UserRole, bool>> predicate)
        {
            return await context.UserRoles.FirstOrDefaultAsync(predicate);

        }
    }
}
