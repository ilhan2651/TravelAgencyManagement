using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Facility;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class FacilityService(IFacilityRepository facilityRepository, IMapper mapper, IUnitOfWork unitOfWork)
       : IFacilityService
    {
        public async Task<ServiceResult> CreateAsync(CreateFacilityDto createFacilityDto)
        {
            var facility = mapper.Map<Facility>(createFacilityDto);
            facility.CreatedAt = DateTime.UtcNow;
            await facilityRepository.AddAsync(facility);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("İmkan başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<List<ListFacilityDto>>> GetAllAsync()
        {
            var query = facilityRepository.GetAllFacilities();
            if (!query.Any())
                return ServiceResult<List<ListFacilityDto>>.Fail("Hiçbir imkan bulunamadı.");

            var list = await query
                .ProjectTo<ListFacilityDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return ServiceResult<List<ListFacilityDto>>.Ok(list);
        }

        public async Task<ServiceResult<FacilityDetailDto>> GetByIdAsync(int id)
        {
            var facility = await facilityRepository.GetFacilityWithDetails(id);
            if (facility == null)
                return ServiceResult<FacilityDetailDto>.Fail("İmkan bulunamadı.");

            var dto = mapper.Map<FacilityDetailDto>(facility);
            return ServiceResult<FacilityDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var facility = await facilityRepository.GetByIdAsync(id);
            if (facility == null)
                return ServiceResult.Fail("İmkan bulunamadı.");
            if (facility.DeletedAt != null)
                return ServiceResult.Fail("İmkan zaten silinmiş.");

            facility.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("İmkan başarıyla silindi.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateFacilityDto updateFacilityDto)
        {
            var facility = await facilityRepository.GetByIdAsync(id);
            if (facility == null)
                return ServiceResult.Fail("İmkan bulunamadı.");

            mapper.Map(updateFacilityDto, facility);
            facility.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("İmkan başarıyla güncellendi.");
        }
    }

}
