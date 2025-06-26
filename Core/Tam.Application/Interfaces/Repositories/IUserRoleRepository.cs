using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IUserRoleRepository : IGenericRepository<UserRole>
    {
        Task<UserRole?> FirstOrDefaultAsync(Expression<Func<UserRole, bool>> predicate);

    }

}
