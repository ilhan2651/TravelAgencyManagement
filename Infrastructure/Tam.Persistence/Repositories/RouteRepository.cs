using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class RouteRepository(TamDbContext context)
        : GenericRepository<Route>(context), IRouteRepository
    {
        public IQueryable<Route> GetRoutes()
        {
            return context.Routes
                .Include(r => r.StartLocation)
                .Include(r => r.EndLocation)
                .Include(r => r.RouteStops!)
                    .ThenInclude(rs => rs.Location)
                .OrderByDescending(r => r.DeletedAt == null)
                .ThenBy(r => r.Name);
        }

        public async Task<Route?> GetRouteWithStopsAsync(int id)
        {
            var route = await context.Routes
                .Include(r => r.StartLocation)
                .Include(r => r.EndLocation)
                .Include(r => r.RouteStops!)
                    .ThenInclude(rs => rs.Location)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (route is not null)
            {
                route.RouteStops = route.RouteStops
                    .OrderBy(rs => rs.Order)
                    .ToList();
            }

            return route;
        }

    }
}
