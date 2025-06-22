using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.PaymentDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<ServiceResult> CreateAsync(CreatePaymentDto dto);
        Task<ServiceResult> UpdateAsync(int id, UpdatePaymentDto dto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<ServiceResult<List<PaymentListDto>>> GetAllAsync();
        Task<ServiceResult<PaymentDetailDto>> GetByIdAsync(int id);
    }
}
