using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IVehicleRepository : IGenericRepository<Vehicle>
    {
        IQueryable<Vehicle> GetAllVehicles();
        Task<Vehicle?> GetVehicleWithDetails(int id);
        IQueryable<Vehicle> SearchVehicles(string term);
    }
}
