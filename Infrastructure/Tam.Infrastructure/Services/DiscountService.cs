using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.DiscountDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class DiscountService(
        IDiscountRepository discountRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : IDiscountService
    {
        public async Task<ServiceResult> CreateAsync(CreateDiscountDto dto)
        {
            var entity = mapper.Map<Discount>(dto);
            await discountRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("İndirim başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateDiscountDto dto)
        {
            var entity = await discountRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("İndirim bulunamadı.");

            mapper.Map(dto, entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("İndirim başarıyla güncellendi.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await discountRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("İndirim bulunamadı.");

            entity.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("İndirim başarıyla silindi.");
        }

        public async Task<ServiceResult<List<ListDiscountDto>>> GetAllAsync()
        {
            var list = await discountRepository.GetAllDiscounts().ToListAsync();
            var dto = mapper.Map<List<ListDiscountDto>>(list);
            return ServiceResult<List<ListDiscountDto>>.Ok(dto);
        }

        public async Task<ServiceResult<ListDiscountDto>> GetByIdAsync(int id)
        {
            var entity = await discountRepository.GetByIdAsync(id);
            if (entity == null || entity.DeletedAt != null)
                return ServiceResult<ListDiscountDto>.Fail("İndirim bulunamadı.");

            var dto = mapper.Map<ListDiscountDto>(entity);
            return ServiceResult<ListDiscountDto>.Ok(dto);
        }
    }
}
