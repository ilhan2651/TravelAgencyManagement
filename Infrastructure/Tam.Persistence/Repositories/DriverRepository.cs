using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class DriverRepository(TamDbContext context) : GenericRepository<Driver>(context), IDriverRepository
    {
        public IQueryable<Driver> GetAllDrivers()
        {
            return context.Drivers
                  .Include(d => d.Supplier)
                  .Include(d => d.DriverLocations)
                  .OrderByDescending(d => d.DeletedAt==null)
                  .ThenBy(d => d.FullName);
                  
        }

        public async Task<Driver> GetDriverWithTransfersAndTours(int id)
        {
            return await context.Drivers
                .Include(d => d.Supplier)
                .Include(d => d.DriverLocations)
                .Include(d => d.DriverTransfers)
                    .ThenInclude(dt => dt.Transfer)
                .Include(d => d.TourDrivers)
                    .ThenInclude(td => td.Tour)
                    .FirstOrDefaultAsync(d => d.Id == id);
                

        }

        public IQueryable<Driver> SearchDrivers(string term)
        {
            term = term.Trim();
            return context.Drivers
                .Where(d =>
                EF.Functions.ILike(PgExtensions.Unaccent(d.FullName), $"%{term}%"));
        }
    }

}
