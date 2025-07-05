using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface ITransferReservationRepository : IGenericRepository<TransferReservation>
    {
        Task<TransferReservation?> GetReservationWithDetailsAsync(int id);
        IQueryable<TransferReservation> GetAllWithGuests();
        IQueryable<TransferReservation> SearchByCustomerName(string name);

    }
}
