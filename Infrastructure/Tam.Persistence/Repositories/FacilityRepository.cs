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
    public class FacilityRepository(TamDbContext context)
     : GenericRepository<Facility>(context), IFacilityRepository
    {
        public IQueryable<Facility> GetAllFacilities()
        {
            return context.Facilities
                .OrderByDescending(f => f.DeletedAt == null)
                .ThenBy(f => f.Name);
        }

        public async Task<Facility> GetFacilityWithDetails(int id)
        {
            return await context.Facilities
                .FirstOrDefaultAsync(f => f.Id == id);
        }
    }

}
