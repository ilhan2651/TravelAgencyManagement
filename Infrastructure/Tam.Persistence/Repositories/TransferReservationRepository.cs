using Microsoft.EntityFrameworkCore;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class TransferReservationRepository(TamDbContext context) : GenericRepository<TransferReservation>(context), ITransferReservationRepository
    {

        public async Task<TransferReservation?> GetReservationWithDetailsAsync(int id)
        {
            return await context.TransferReservations
                .Include(x => x.Guests)
                .Include(x => x.Transfer)
                .Include(x => x.Customer)
                .Include(x => x.Discount)
                .Include(x => x.Payment)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<TransferReservation> GetAllWithGuests()
        {
            return context.TransferReservations
                .Include(x => x.Transfer)
                .Include(x => x.Customer);
        }

        public IQueryable<TransferReservation> SearchByCustomerName(string name)
        {
            
                name = name.Trim();

                return context.TransferReservations
                    .Include(x => x.Customer)
                    .Where(x =>
                        EF.Functions.ILike(
                            PgExtensions.Unaccent(x.Customer.FullName),
                            $"%{name}%"
                        )
                    );
            

        }
    }
}
