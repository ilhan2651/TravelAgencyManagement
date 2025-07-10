using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class TourReservationRepository(TamDbContext context)
        : GenericRepository<TourReservation>(context), ITourReservationRepository
    {
        public async Task<TourReservation?> GetReservationWithDetailsAsync(int id)
        {
            return await context.TourReservations
                .Include(x => x.Tour)
                .Include(x => x.Customer)
                .Include(x => x.Discount)
                .Include(x => x.Payment)
                .Include(x => x.Invoice)
                .Include(x => x.Guests)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TourReservation> GetAllWithDetails()
        {
            return context.TourReservations
                .OrderByDescending(x => x.DeletedAt==null)
                .ThenBy(x=>x.ReservationDate)
                .Include(x => x.Tour)
                .Include(x => x.Customer);
        }

        public IQueryable<TourReservation> SearchByCustomerName(string name)
        {
            name = name.Trim();

            return context.TourReservations
                .Include(x => x.Customer)
                .Include(x => x.Tour)
                .Include(x => x.Guests)
                .Where(x =>
                    EF.Functions.ILike(PgExtensions.Unaccent(x.Customer.FullName), $"%{name}%") ||
                    EF.Functions.ILike(PgExtensions.Unaccent(x.Tour.Name), $"%{name}%") ||
                    x.Guests.Any(g =>
                        EF.Functions.ILike(PgExtensions.Unaccent(g.FullName), $"%{name}%")
                    ));
        }

    }
}