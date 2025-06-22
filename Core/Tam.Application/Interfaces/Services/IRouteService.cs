using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RouteDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IRouteService
    {
        Task<ServiceResult<List<RouteListDto>>> GetAllAsync();
        Task<ServiceResult<RouteDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateRouteDto createDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateRouteDto updateDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
    }
}
