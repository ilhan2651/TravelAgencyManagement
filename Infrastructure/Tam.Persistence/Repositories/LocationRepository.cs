using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class LocationRepository(TamDbContext context) : GenericRepository<Location>(context), ILocationRepository
    {
        public IQueryable<Location> GetLocations()
        {
            return context.Locations.OrderByDescending(l=>l.DeletedAt==null)
                .ThenBy(l => l.City);
        }

        public IQueryable<Location> SearchLocations(string term)
        {
            term = term.Trim().ToLower();
            return context.Locations.Where(l =>
                (l.City.ToLower().Contains(term)) ||
                (l.Country != null && l.Country.ToLower().Contains(term)) ||
                (l.District != null && l.District.ToLower().Contains(term)));
        }
    }
}