using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class RegionRepository(TamDbContext context) : GenericRepository<Region>(context), IRegionRepository
    {
        public IQueryable<Region> GetRegions()
        {
            return context.Regions.OrderByDescending(r => r.DeletedAt == null)
                .ThenBy(r => r.Name);
        }

        public IQueryable<Region> SearchRegions(string term)
        {
            term = term.Trim();

            return context.Regions.Where(r =>
                EF.Functions.ILike(PgExtensions.Unaccent(r.Name), $"%{term}%"));
        }

    }
}