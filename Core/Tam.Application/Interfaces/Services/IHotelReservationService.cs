using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.HotelReservationDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IHotelReservationService
    {
        Task<ServiceResult> CreateAsync(CreateHotelReservationDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateHotelReservationDto dto);
        Task<ServiceResult> DeleteAsync(int id);

        Task<ServiceResult<List<ListHotelReservationDto>>> GetAllAsync();
        Task<ServiceResult<List<ListHotelReservationDto>>> GetByDateRangeAsync(DateTime start, DateTime end);
        Task<ServiceResult<List<HotelReservationSearchResultDto>>> SearchByCustomerNameAsync(string name);
        Task<ServiceResult<HotelReservationDetailDto>> GetByIdAsync(int id);
    }
}
