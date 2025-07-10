using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface ITourReservationRepository : IGenericRepository<TourReservation>
    {
        Task<TourReservation?> GetReservationWithDetailsAsync(int id);
        IQueryable<TourReservation> GetAllWithDetails();
        IQueryable<TourReservation> SearchByCustomerName(string name);
    }
}