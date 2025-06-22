using Microsoft.EntityFrameworkCore;

using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class GuideRepository(TamDbContext context) : GenericRepository<Guide>(context), IGuideRepository
    {
        public IQueryable<Guide> GetAllGuides()
        {
            return context.Guides
                .OrderByDescending(g => g.DeletedAt == null)
                .ThenBy(g => g.FullName);
        }

        public async Task<Guide> GetGuideWithDetails(int id)
        {
            return  await context.Guides
                .Include(g => g.GuideLanguages)
                .Include(g => g.GuideLocations)
                .ThenInclude(gl => gl.Location)
                .Include(g => g.GuideRegions)
                .ThenInclude(gr => gr.Region)
                .Include(g => g.Tours)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public IQueryable<Guide> SearchGuides(string searchTerm)
        {
            searchTerm = searchTerm.Trim();

            return context.Guides.Where(g =>
                EF.Functions.ILike(
                    PgExtensions.Unaccent(g.FullName),   
                    $"%{searchTerm}%"));
        }

    }
}
