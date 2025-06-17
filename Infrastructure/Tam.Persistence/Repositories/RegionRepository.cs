using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
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
            term = term.Trim().ToLower();
            return context.Regions.Where(r => r.Name.ToLower().Contains(term));
        }
    }
}