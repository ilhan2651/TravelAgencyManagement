using Microsoft.EntityFrameworkCore;
using Tam.Domain.Entities;
using Tam.Application.Interfaces.Repositories;
using Tam.Persistence.Context;
using Tam.Infrastructure.Extensions;

namespace Tam.Persistence.Repositories
{
    public class HotelReservationRepository(TamDbContext context)
        : GenericRepository<HotelReservation>(context), IHotelReservationRepository
    {
        public IQueryable<HotelReservation> GetAllForList()
        {
            return context.HotelReservations
                .Include(x => x.Customer)
                .Include(x => x.Hotel)
                .Where(x => x.DeletedAt == null);
        }

        public IQueryable<HotelReservation> GetByDateRange(DateTime start, DateTime end)
        {
            return context.HotelReservations
                .Include(x => x.Customer)
                .Include(x => x.Hotel)
                .Where(x => x.DeletedAt == null &&
                            x.ReservationDate >= start.Date &&
                            x.ReservationDate <= end.Date);
        }

        public IQueryable<HotelReservation> SearchByCustomerName(string name)
        {
            name = name.Trim();
            return context.HotelReservations
                .Include(x => x.Customer)
                .Include(x => x.Hotel)
                .Where(x => x.DeletedAt == null &&
                            EF.Functions.ILike(PgExtensions.Unaccent(x.Customer.FullName), $"%{name}%"));
        }

        public async Task<HotelReservation> GetReservationByIdAsync(int id)
        {
            return await context.HotelReservations
                .Include(x => x.Customer)
                .Include(x => x.Hotel)
                .Include(x => x.Discount)
                .Include(x => x.Payment)
                .Include(x => x.ReservedRooms).ThenInclude(rr => rr.HotelRoomOption).ThenInclude(opt => opt.RoomType)
                .Include(x => x.Guests)
                .FirstOrDefaultAsync(x => x.Id == id && x.DeletedAt == null);
        }
    }
}
