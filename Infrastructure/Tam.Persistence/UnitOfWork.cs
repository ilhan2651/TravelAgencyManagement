using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Persistence.Context;

namespace Tam.Persistence
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly TamDbContext _context;

        public UnitOfWork(TamDbContext context)
        {
            _context = context;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

    }
}
