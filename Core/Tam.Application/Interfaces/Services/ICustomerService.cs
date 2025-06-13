using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.CustomerDtos;
using Tam.Application.Dtos.UserDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<ServiceResult> CreateCustomerAsync(CreateCustomerDto createDto );
        Task<ServiceResult> SoftDeleteCustomerAsync(int customerId);
        Task<ServiceResult> UpdateCustomerAsync(int customerId, UpdateCustomerDto updateDto);
        Task<ServiceResult<CustomerListDto>> GetUserByIdAsync(int customerId);
        Task<ServiceResult<PagedResult<CustomerListDto>>> GetAllCustomersAsync(int page, int pageSize);
        Task<ServiceResult<PagedResult<CustomerListDto>>> SearchCustomerAsync(string searchTerm,int page, int pageSize);  
    }
}
