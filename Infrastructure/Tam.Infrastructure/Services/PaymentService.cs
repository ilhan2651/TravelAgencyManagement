using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.PaymentDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class PaymentService(IPaymentRepository paymentRepository,
         IMapper mapper,
         IUnitOfWork unitOfWork) : IPaymentService
    {

        public async Task<ServiceResult> CreateAsync(CreatePaymentDto dto)
        {
            var entity = mapper.Map<Payment>(dto);
            await paymentRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Ödeme başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdatePaymentDto dto)
        {
            var entity = await paymentRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Ödeme bulunamadı.");

            mapper.Map(dto, entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Ödeme başarıyla güncellendi.");
        }

        public async Task<ServiceResult<List<PaymentListDto>>> GetAllAsync()
        {
            var payments = await paymentRepository.GetAllWithMethodAsync();
            if(payments==null)
                return ServiceResult<List<PaymentListDto>>.Fail("Ödeme bulunamadı.");
            var result= mapper.Map<List<PaymentListDto>>(payments);
            return ServiceResult<List<PaymentListDto>>.Ok(result);
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
           var payment = await paymentRepository.GetByIdAsync(id);
            if (payment == null)
                return ServiceResult.Fail("Ödeme bulunamadı.");

            payment.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Ödeme başarıyla silindi.");
            
        }

        public async  Task<ServiceResult<PaymentDetailDto>> GetByIdAsync(int id)
        {
            var payment = await paymentRepository.GetPaymentByIdAsync(id);
            if(payment==null)
                return ServiceResult<PaymentDetailDto>.Fail("Ödeme bulunamadı.");
            var result = mapper.Map<PaymentDetailDto>(payment);
            return ServiceResult<PaymentDetailDto>.Ok(result);
        }
    }
}
