using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Aprantee;

namespace Tam.Application.Interfaces.Services
{
    public interface IAppranteeService
    {
        Task<ServiceResult<List<ListAppranteeDto>>> GetAllActiveAsync();
        Task<ServiceResult<List<ListAppranteeDto>>> GetAllPassiveAsync();
        Task<ServiceResult<ListAppranteeDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateAppranteeDto createApprenteeDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateAppranteeDto updateApprenteeDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
    }
}
