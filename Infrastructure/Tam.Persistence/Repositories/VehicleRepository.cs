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
    public class VehicleRepository(TamDbContext context) : GenericRepository<Vehicle>(context) , IVehicleRepository
    {
        public IQueryable<Vehicle> GetAllVehicles()
        {
            return context.Vehicles
                .Include(v => v.Supplier)
                .OrderByDescending(v => v.DeletedAt==null)
                .ThenBy(v => v.PlateNumber);
        }
        public async Task<Vehicle?> GetVehicleWithDetails(int id)
        {
            return await context.Vehicles
                .Include(v => v.Supplier)
                .Include(v => v.TourVehicles)
                    .ThenInclude(tv => tv.Tour)
                .Include(v => v.TransferVehicles)
                    .ThenInclude(tv => tv.Transfer)
                .FirstOrDefaultAsync(v => v.Id == id);
        }
        public IQueryable<Vehicle> SearchVehicles(string term)
        {
            return context.Vehicles.Where(v =>
                EF.Functions.Like(v.PlateNumber, $"%{term}%") ||
                v.Brand.Contains(term) ||
                v.Model.Contains(term));
        }
    }
}
