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
    public class TransferRepository(TamDbContext context) : GenericRepository<Transfer>(context), ITransferRepository
    {
        public IQueryable<Transfer> GetAllTransfers()
        {
            return context.Transfers
          .Include(t => t.StartLocation)
          .Include(t => t.EndLocation)
          .Include(t => t.Route)
          .OrderByDescending(t => t.DeletedAt==null)
          .ThenBy(t=>t.CreatedAt);
        }

        public async Task<Transfer?> GetTransferWithDetailsAsync(int id)
        {
            return await context.Transfers
               .Include(t => t.StartLocation)
               .Include(t => t.EndLocation)
               .Include(t => t.Route)
                   .ThenInclude(r => r.RouteStops)
                       .ThenInclude(rs => rs.Location)
               .Include(t => t.TransferReservations)
                   .ThenInclude(tr => tr.Customer)
               .Include(t => t.DriverTransfers)
                   .ThenInclude(dt => dt.Driver)
               .Include(t => t.TransferVehicles)
                   .ThenInclude(tv => tv.Vehicle)
               .FirstOrDefaultAsync(t => t.Id == id);
        }

        public IQueryable<Transfer> SearchTransfers(string term)
        {
            term = term.Trim().ToLower();
            return context.Transfers
                .Where(t => EF.Functions.ILike(PgExtensions.Unaccent(t.Name), $"%{term}%"))
                .Include(t => t.StartLocation)
                .Include(t => t.EndLocation);
        }
    }
}
