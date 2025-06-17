using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.VehicleDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IVehicleService
    {
        Task<ServiceResult> CreateAsync(CreateVehicleDto createDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateVehicleDto updateDto);
        Task<ServiceResult> SoftDeleteAsync(int id);

        Task<ServiceResult<PagedResult<VehicleListDto>>> GetAllAsync(int page, int pageSize);
        Task<ServiceResult<VehicleDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult<List<VehicleSearchResultDto>>> SearchAsync(string term);
    }
}
