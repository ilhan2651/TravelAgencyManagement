using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Facility;

namespace Tam.Application.Interfaces.Services
{
    public interface IFacilityService
    {
        Task<ServiceResult> CreateAsync(CreateFacilityDto createFacilityDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateFacilityDto updateFacilityDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult<List<ListFacilityDto>>> GetAllAsync();
        Task<ServiceResult<FacilityDetailDto>> GetByIdAsync(int id);
    }
}
