using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IFacilityRepository : IGenericRepository<Facility>
    {
        IQueryable<Facility> GetAllFacilities();
        Task<Facility> GetFacilityWithDetails(int id);
    }

}
