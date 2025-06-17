using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Region;

namespace Tam.Application.Interfaces.Services
{
    public interface IRegionService
    {
        Task<ServiceResult<List<RegionListDto>>> GetAllAsync();
        Task<ServiceResult<RegionListDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateRegionDto createRegionDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateRegionDto updateRegionDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
    }
}
