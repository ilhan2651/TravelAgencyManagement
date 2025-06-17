using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface ILocationRepository : IGenericRepository<Location>
    {
        IQueryable<Location> GetLocations();
        IQueryable<Location> SearchLocations(string term);
    }
}
