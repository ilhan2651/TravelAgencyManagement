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
    public class HotelRoomOptionRepository(TamDbContext context) : GenericRepository<HotelRoomOption>(context), IHotelRoomOptionRepository
    {
        public IQueryable<HotelRoomOption> GetAllOptions()
        {
            return context.HotelRoomOptions
                .Include(h=> h.RoomType)
                .OrderByDescending(h => h.DeletedAt == null)
                .ThenBy(h=>h.PricePerNight);
        }

        public async Task<HotelRoomOption> GetOptionByIdAsync(int id)
        {
           return await context.HotelRoomOptions
                .Include(h => h.RoomType)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
