using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.PaymentMethodDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class PaymentMethodService(IPaymentMethodRepository paymentMethodRepository,IUnitOfWork unitOfWork, IMapper mapper ) : IPaymentMethodService
    {
        public async Task<ServiceResult> CreateMethod(CreatePaymentMethodDto dto)
        {
           var entity= mapper.Map<PaymentMethod>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            await paymentMethodRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Ödeme yöntemi başarıyla oluşturuldu");
        }

        public async Task<ServiceResult<List<ListPaymentMethodDto>>> GetAllMethods()
        {
            var methods = await paymentMethodRepository.GetAllMethodsAsync();
             if ( methods == null ) 
                return ServiceResult<List<ListPaymentMethodDto>>.Fail("Ödeme yöntemleri bulunamadı");
             var result = mapper.Map<List<ListPaymentMethodDto>>(methods);
            return ServiceResult<List<ListPaymentMethodDto>>.Ok(result);
        }

        public async Task<ServiceResult<ListPaymentMethodDto>> GetMethodById(int id)
        {
            var method = await paymentMethodRepository.GetByIdAsync(id);
            if (method == null)
                return ServiceResult<ListPaymentMethodDto>.Fail("Ödeme yöntemi bulunamadı");
            var dto = mapper.Map<ListPaymentMethodDto>(method);
            return ServiceResult<ListPaymentMethodDto>.Ok(dto);

        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var deletedMethod =await paymentMethodRepository.GetByIdAsync(id);
            if (deletedMethod == null)
                return ServiceResult.Fail("Ödeme yöntemi bulunamadı");
            if (deletedMethod.DeletedAt != null)
                return ServiceResult.Fail("Ödeme yöntemi zaten silinmiş");
            deletedMethod.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Ödeme yöntemi başarıyla silindi");
        }

        public async Task<ServiceResult> UpdateMethod(int id ,UpdatePaymentMethodDto dto)
        {
            var entity = await paymentMethodRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Ödeme yöntemi bulunamadı");
            mapper.Map(dto, entity);
            entity.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Ödeme yöntemi başarıyla güncellendi");

        }
    }
}
