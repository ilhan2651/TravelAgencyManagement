using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IHotelReservationRepository : IGenericRepository<HotelReservation>
    {
        IQueryable<HotelReservation> GetAllForList();
        IQueryable<HotelReservation> SearchByCustomerName(string name);
        IQueryable<HotelReservation> GetByDateRange(DateTime start, DateTime end);
        Task<HotelReservation> GetReservationByIdAsync(int id);

    }
}
