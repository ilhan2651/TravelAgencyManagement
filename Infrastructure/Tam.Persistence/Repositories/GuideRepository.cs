using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
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
                .Include(g => g.GuideLocations)
                .ThenInclude(gl => gl.Location)
                .Include(g => g.GuideRegions)
                .ThenInclude(gr => gr.Region)
                .Include(g => g.Tours)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public IQueryable<Guide> SearchGuides(string searchTerm)
        {
            return context.Guides.Where(v =>
                EF.Functions.Like(v.FullName, $"%{searchTerm}%"));
        }
    }
}
