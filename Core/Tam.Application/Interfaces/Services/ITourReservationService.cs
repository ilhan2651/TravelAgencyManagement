using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.TourReservationDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface ITourReservationService
    {
        Task<ServiceResult> CreateAsync(CreateTourReservationDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateTourReservationDto dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<ListTourReservationDto>>> GetAllAsync();
        Task<ServiceResult<TourReservationDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult<TourReservationSearchResultDto>> Search(string searchTerm);
    }
}