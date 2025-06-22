using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.PaymentMethodDtos;

namespace Tam.Application.Interfaces.Services
{
    public interface IPaymentMethodService
    {
        Task<ServiceResult<List<ListPaymentMethodDto>>> GetAllMethods();
        Task<ServiceResult<ListPaymentMethodDto>> GetMethodById(int id);
        Task<ServiceResult> CreateMethod(CreatePaymentMethodDto dto);
        Task<ServiceResult> UpdateMethod(int id,UpdatePaymentMethodDto dto);
        Task<ServiceResult> SoftDeleteAsync(int id);
    }
}
