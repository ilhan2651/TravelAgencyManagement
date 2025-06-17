using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.DriverDto;
using Tam.Application.Dtos.DriverDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IDriverService
    {
        Task<ServiceResult> CreateAsync(CreateDriverDto createDriverDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateDriverDto updateDriverDto);
        Task<ServiceResult> SoftDeleteDriverAsync(int id);

        Task<ServiceResult<PagedResult<DriverListDto>>> GetAllAsync(int page, int pageSize);
        Task<ServiceResult<DriverDetailDto>> GetByIdAsync(int id);

        Task<ServiceResult<List<DriverSearchResultDto>>> SearchAsync(string searchTerm);
    }
}

