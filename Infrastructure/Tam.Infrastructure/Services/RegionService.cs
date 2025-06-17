using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Application.Dtos.Region;

namespace Tam.Infrastructure.Services
{
    public class RegionService(IRegionRepository regionRepository, IMapper mapper, IUnitOfWork unitOfWork) : IRegionService
    {
        public async Task<ServiceResult> CreateAsync(CreateRegionDto createRegionDto)
        {
            var region = mapper.Map<Region>(createRegionDto);
            region.CreatedAt = DateTime.UtcNow;

            await regionRepository.AddAsync(region);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Bölge başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<List<RegionListDto>>> GetAllAsync()
        {
            var regions = await regionRepository.GetRegions()
                .ProjectTo<RegionListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return regions.Any()
                ? ServiceResult<List<RegionListDto>>.Ok(regions)
                : ServiceResult<List<RegionListDto>>.Fail("Hiçbir bölge bulunamadı.");
        }

        public async Task<ServiceResult<RegionListDto>> GetByIdAsync(int id)
        {
            var region = await regionRepository.GetByIdAsync(id);
            if (region == null)
                return ServiceResult<RegionListDto>.Fail("Bölge bulunamadı.");
            var dto = mapper.Map<RegionListDto>(region);
            return ServiceResult<RegionListDto>.Ok(dto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateRegionDto updateRegionDto)
        {
            var region = await regionRepository.GetByIdAsync(id);
            if (region == null)
                return ServiceResult.Fail("Bölge bulunamadı.");
            mapper.Map(updateRegionDto, region);
            region.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Bölge başarıyla güncellendi.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var region = await regionRepository.GetByIdAsync(id);
            if (region == null)
                return ServiceResult.Fail("Bölge bulunamadı.");
            if (region.DeletedAt != null)
                return ServiceResult.Fail("Bölge zaten silinmiş.");
            region.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Bölge başarıyla silindi.");
        }
    }
}