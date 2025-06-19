using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
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
            term = term.Trim();

            return context.Locations.Where(l =>
                EF.Functions.ILike(PgExtensions.Unaccent(l.City), $"%{term}%") ||
                (l.Country != null && EF.Functions.ILike(PgExtensions.Unaccent(l.Country), $"%{term}%")) ||
                (l.District != null && EF.Functions.ILike(PgExtensions.Unaccent(l.District), $"%{term}%")));
        }

    }
}