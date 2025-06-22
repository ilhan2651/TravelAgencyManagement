using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class HotelRepository(TamDbContext context) : GenericRepository<Hotel>(context), IHotelRepository
    {
        public IQueryable<Hotel> GetAllHotels()
        {
            return context.Hotels
                .Include(h => h.Location)
                .Include(h => h.HotelFacilities)
                    .ThenInclude(hf => hf.Facility)
                .OrderByDescending(h => h.DeletedAt == null)
                .ThenBy(h => h.Name);
        }

        public async Task<Hotel?> GetHotelWithFacilities(int id)
        {
            return await context.Hotels
                .Include(h=>h.RoomOptions)
                    .ThenInclude(h => h.RoomType)
                .Include(h => h.Location)
                .Include(h => h.HotelFacilities)
                    .ThenInclude(hf => hf.Facility)
                .FirstOrDefaultAsync(h => h.Id == id);
        }

        public IQueryable<Hotel> SearchHotels(string searchTerm)
        {
            searchTerm=searchTerm.Trim().ToLower();
            return context.Hotels
                .Include(h => h.Location)
                .Where(h => EF.Functions.ILike(PgExtensions.Unaccent(h.Name), $"%{searchTerm.Trim().ToLower()}%"));
        }
    }

}
