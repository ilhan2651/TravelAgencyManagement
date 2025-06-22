using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.Transfer;

namespace Tam.Application.Interfaces.Services
{
    public interface ITransferService
    {
        Task<ServiceResult<PagedResult<TransferListDto>>> GetAllAsync(int page, int pageSize);
        Task<ServiceResult<TransferDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateTransferDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateTransferDto dto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult> AssignDriversAsync(int transferId, List<int> driverIds);
        Task<ServiceResult> AssignVehiclesAsync(int transferId, List<int> vehicleIds);
        Task<ServiceResult> RemoveDriverAsync(int transferId, int driverId);
        Task<ServiceResult> RemoveVehicleAsync(int transferId, int vehicleId);
    }
}
