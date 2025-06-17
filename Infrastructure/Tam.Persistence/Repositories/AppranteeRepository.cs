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
    public class AppranteeRepository(TamDbContext context) : GenericRepository<Apprantee>(context), IAppranteeRepository
    {
        public async Task<List<Apprantee>> GetActiveAppranties()
        {
            return await context.Apprantees
                .Where(a => a.DeletedAt ==null)
                .ToListAsync();
        }

        public async Task<List<Apprantee>> GetPassiveAppranties()
        {
            return await context.Apprantees
                .Where(a => a.DeletedAt !=null)
                .ToListAsync();
        }
    }
}
