using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class TourRepository(TamDbContext context) : GenericRepository<Tour>(context), ITourRepository
    {
        public IQueryable<Tour> GetAllTours()
        {
            return context.Tours
                .Include(t => t.StartLocation)
                .Include(t => t.EndLocation)
                .Include(t => t.Category)
                .Include(t => t.Guide)
                .OrderByDescending(t => t.DeletedAt == null)
                .ThenBy(t => t.CreatedAt);
        }

        public async Task<Tour?> GetTourWithDetailsAsync(int id)
        {
            return await context.Tours
                .Include(t => t.Guide)
                .Include(t => t.Apprantee)
                .Include(t => t.Category)
                .Include(t => t.StartLocation)
                .Include(t => t.EndLocation)
                .Include(t => t.Route)
                    .ThenInclude(r => r.RouteStops)
                        .ThenInclude(rs => rs.Location)
                .Include(t => t.TourVehicles)
                    .ThenInclude(tv => tv.Vehicle)
                .Include(t => t.TourDrivers)
                    .ThenInclude(td => td.Driver)
                .Include(t => t.TourHotels)
                    .ThenInclude(th => th.Hotel)
                        .ThenInclude(h => h.Location)
                .Include(t => t.TourRegions)
                    .ThenInclude(tr => tr.Region)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public IQueryable<Tour> SearchTours(string term)
        {
            term = term.Trim().ToLower();
            return context.Tours
                .Where(t => EF.Functions.ILike(PgExtensions.Unaccent(t.Name), $"%{term}%"))
                .Include(t => t.StartLocation)
                .Include(t => t.EndLocation);
        }
    }
}