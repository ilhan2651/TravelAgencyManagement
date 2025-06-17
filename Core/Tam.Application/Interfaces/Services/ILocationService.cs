using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.LocationDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface ILocationService
    {
        Task<ServiceResult<List<LocationListDto>>> GetAllAsync();
        Task<ServiceResult<LocationListDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateLocationDto createLocationDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateLocationDto updateLocationDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
    }
}
