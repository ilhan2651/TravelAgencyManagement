using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.DriverDto;
using Tam.Application.Dtos.DriverDtos;
using Tam.Application.Dtos.Guide;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class GuideService(IGuideRepository guideRepository, IMapper mapper, IUnitOfWork unitOfWork ) : IGuideService
    {
        public async Task<ServiceResult> CreateAsync(CreateGuideDto createGuideDto)
        {
           var guide = mapper.Map<Guide>(createGuideDto);
            guide.CreatedAt=DateTime.UtcNow;
            await guideRepository.AddAsync(guide);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rehber başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<PagedResult<ListGuideDto>>> GetAllAsync(int page, int pageSize)
        {
            var query =  guideRepository.GetAllGuides();
            if (!query.Any())
                return ServiceResult<PagedResult<ListGuideDto>>.Fail("Hiçbir sürücü bulunamadı.");
            var pagedResult = await query
                .ProjectToPagedResultAsync<Guide, ListGuideDto>(
                mapper.ConfigurationProvider,
                page,
                pageSize
            );
            return ServiceResult<PagedResult<ListGuideDto>>.Ok(pagedResult);
        }

        public async Task<ServiceResult<GuideDetailDto>> GetByIdAsync(int id)
        {
            var guide =await  guideRepository.GetGuideWithDetails(id);
            if (guide == null) 
                return ServiceResult<GuideDetailDto>.Fail("Rehber bulunamadı.");
            var guideDetailDto = mapper.Map<GuideDetailDto>(guide);
            return ServiceResult<GuideDetailDto>.Ok(guideDetailDto);

        }

        public async  Task<ServiceResult<List<GuideSearchResultDto>>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<List<GuideSearchResultDto>>.Fail("Arama terimi boş olamaz.");
            var result =await  guideRepository.SearchGuides(searchTerm.Trim())
                .ProjectTo<GuideSearchResultDto>(mapper.ConfigurationProvider)
                .ToListAsync();
            return result.Any()
               ? ServiceResult<List<GuideSearchResultDto>>.Ok(result)
               : ServiceResult<List<GuideSearchResultDto>>.Fail("Eşleşen rehber bulunamadı.");
        }

        public async Task<ServiceResult> SoftDeleteGuideAsync(int id)
        {
           var guide =  await guideRepository.GetByIdAsync(id);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");
            if( guide.DeletedAt !=null)
                return ServiceResult.Fail("Rehber zaten silinmiş.");
            guide.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rehber başarıyla silindi.");
         
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateGuideDto updateGuideDto)
        {
            var guide = await guideRepository.GetByIdAsync(id);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");
            mapper.Map(updateGuideDto, guide);
            guide.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rehber başarıyla güncellendi.");

        }
    }
}
