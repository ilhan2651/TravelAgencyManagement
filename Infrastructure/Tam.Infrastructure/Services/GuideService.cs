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
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Domain.Entities.JoinTables;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class GuideService(IGuideRepository guideRepository, IMapper mapper, IUnitOfWork unitOfWork) : IGuideService
    {
        public async Task<ServiceResult> AssignLanguagesAsync(int guideId, List<int> languageIds)
        {
            var guide = await guideRepository.GetGuideWithDetails(guideId);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");

            foreach (var languageId in languageIds.Distinct())
            {
                bool alreadyExists = guide.GuideLanguages.Any(gl => gl.LanguageId == languageId);
                if (!alreadyExists)
                {
                    var guideLanguage = GuideLanguageFactory.Create(guide.Id, languageId);
                    guide.GuideLanguages.Add(guideLanguage);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Diller başarıyla atandı.");
        }


        public async Task<ServiceResult> AssignLocationsAsync(int guideId, List<int> locationIds)
        {
            var guide = await guideRepository.GetGuideWithDetails(guideId);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");

            foreach (var locationId in locationIds.Distinct())
            {
                bool alreadyExists = guide.GuideLocations.Any(gl => gl.LocationId == locationId);
                if (!alreadyExists)
                {
                    var guideLocation = GuideLocationFactory.Create(guide.Id, locationId);
                    guide.GuideLocations.Add(guideLocation);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Konumlar başarıyla atandı.");
        }


        public async Task<ServiceResult> AssignRegionsAsync(int guideId, List<int> regionIds)
        {
            var guide = await guideRepository.GetGuideWithDetails(guideId);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");

            foreach (var regionId in regionIds.Distinct())
            {
                bool alreadyExist = !guide.GuideRegions.Any(gr => gr.RegionId == regionId);
                if (!alreadyExist)
                {
                    var guideRegion = GuideRegionFactory.Create(guide.Id, regionId);
                    guide.GuideRegions.Add(guideRegion);
                }
            }
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Bölgeler başarıyla atandı.");

        }

        public async Task<ServiceResult> CreateAsync(CreateGuideDto createGuideDto)
        {
            var guide = mapper.Map<Guide>(createGuideDto);
            guide.CreatedAt = DateTime.UtcNow;
            await guideRepository.AddAsync(guide);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rehber başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<PagedResult<ListGuideDto>>> GetAllAsync(int page, int pageSize)
        {
            var query = guideRepository.GetAllGuides();
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
            var guide = await guideRepository.GetGuideWithDetails(id);
            if (guide == null)
                return ServiceResult<GuideDetailDto>.Fail("Rehber bulunamadı.");
            var guideDetailDto = mapper.Map<GuideDetailDto>(guide);
            return ServiceResult<GuideDetailDto>.Ok(guideDetailDto);

        }

        public async Task<ServiceResult> RemoveLanguageAsync(int guideId, int languageId)
        {
            var guide = await guideRepository.GetGuideWithDetails(guideId);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");

            var languageToRemove = guide.GuideLanguages.FirstOrDefault(gl => gl.LanguageId == languageId);
            if (languageToRemove == null)
                return ServiceResult.Fail("Bu dil zaten rehbere ait değil.");

            guide.GuideLanguages.Remove(languageToRemove);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Dil başarıyla kaldırıldı.");
        }


        public async Task<ServiceResult> RemoveLocationAsync(int guideId, int locationId)
        {
            var guide = await guideRepository.GetGuideWithDetails(guideId);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");

            var locationToRemove = guide.GuideLocations.FirstOrDefault(gl => gl.LocationId == locationId);
            if (locationToRemove == null)
                return ServiceResult.Fail("Bu konum zaten rehbere ait değil.");

            guide.GuideLocations.Remove(locationToRemove);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Konum başarıyla kaldırıldı.");
        }


        public async Task<ServiceResult> RemoveRegionsAsync(int guideId, int regionId)
        {
            var guide = await guideRepository.GetGuideWithDetails(guideId);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");
            var regionToRemove = guide.GuideRegions.FirstOrDefault(gr => gr.RegionId == regionId);
            if( regionToRemove == null )
                return ServiceResult.Fail("Rehber bu bölgeye zaten atanmadı.");
            guide.GuideRegions.Remove(regionToRemove);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Bölge başarıyla kaldırıldı.");
        }

        public async Task<ServiceResult<List<GuideSearchResultDto>>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<List<GuideSearchResultDto>>.Fail("Arama terimi boş olamaz.");
            var result = await guideRepository.SearchGuides(searchTerm.Trim().ToLower())
                .ProjectTo<GuideSearchResultDto>(mapper.ConfigurationProvider)
                .ToListAsync();
            return result.Any()
               ? ServiceResult<List<GuideSearchResultDto>>.Ok(result)
               : ServiceResult<List<GuideSearchResultDto>>.Fail("Eşleşen rehber bulunamadı.");
        }

        public async Task<ServiceResult> SoftDeleteGuideAsync(int id)
        {
            var guide = await guideRepository.GetByIdAsync(id);
            if (guide == null)
                return ServiceResult.Fail("Rehber bulunamadı.");
            if (guide.DeletedAt != null)
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
