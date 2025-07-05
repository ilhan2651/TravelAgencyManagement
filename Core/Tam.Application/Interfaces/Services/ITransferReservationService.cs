using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.TransferReservationDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface ITransferReservationService
    {
        Task<ServiceResult> CreateAsync(CreateTransferReservationDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateTransferReservationDto dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<ListTransferReservationDto>>> GetAllAsync();
        Task<ServiceResult<TransferReservationDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult<TransferReservationSearchResultDto>> Search(string searchTerm);
    }
}
