using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.DiscountDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IDiscountService
    {
        Task<ServiceResult> CreateAsync(CreateDiscountDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdateDiscountDto dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<List<ListDiscountDto>>> GetAllAsync();
        Task<ServiceResult<ListDiscountDto>> GetByIdAsync(int id);
    }

}
