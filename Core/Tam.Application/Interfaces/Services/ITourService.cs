using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.TourDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface ITourService
    {
        Task<ServiceResult<PagedResult<TourListDto>>> GetAllAsync(int page, int pageSize);
        Task<ServiceResult<TourDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateTourDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateTourDto dto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult<List<TourSearchResultDto>>> SearchAsync(string term);
        Task<ServiceResult> AssignDriversAsync(int tourId, List<int> driverIds);
        Task<ServiceResult> AssignVehiclesAsync(int tourId, List<int> vehicleIds);
        Task<ServiceResult> AssignHotelsAsync(int tourId, List<int> hotelIds);
        Task<ServiceResult> AssignRegionsAsync(int tourId, List<int> regionIds);
        Task<ServiceResult> RemoveDriverAsync(int tourId, int driverId);
        Task<ServiceResult> RemoveVehicleAsync(int tourId, int vehicleId);
        Task<ServiceResult> RemoveHotelAsync(int tourId, int hotelId);
        Task<ServiceResult> RemoveRegionAsync(int tourId, int regionId);
    }
}