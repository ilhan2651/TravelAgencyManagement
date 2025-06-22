using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.HotelDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IHotelService
    {
        Task<ServiceResult> CreateAsync(CreateHotelDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateHotelDto dto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult> AssignFacilitiesAsync(int hotelId, List<int> facilityIds);
        Task<ServiceResult> RemoveFacilityAsync(int hotelId, int facilityId);

        Task<ServiceResult<PagedResult<ListHotelDto>>> GetAllAsync(int page, int pageSize);
        Task<ServiceResult<HotelDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<HotelSearchResultDto>>> SearchAsync(string searchTerm);
    }

}
