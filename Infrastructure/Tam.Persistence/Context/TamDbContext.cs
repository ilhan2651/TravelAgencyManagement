using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Persistence.Context
{
    public class TamDbContext : DbContext
    {
        public TamDbContext(DbContextOptions<TamDbContext> options):base(options)
        {
            
        }

        public DbSet<ActionLog> MyProperty { get; set; }

    }
}
