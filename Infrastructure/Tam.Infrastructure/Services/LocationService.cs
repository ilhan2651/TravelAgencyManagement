using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.LocationDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class LocationService(ILocationRepository locationRepository, IMapper mapper, IUnitOfWork unitOfWork) : ILocationService
    {
        public async Task<ServiceResult> CreateAsync(CreateLocationDto createLocationDto)
        {
            var location = mapper.Map<Location>(createLocationDto);
            location.CreatedAt = DateTime.UtcNow;

            await locationRepository.AddAsync(location);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Konum başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<List<LocationListDto>>> GetAllAsync()
        {
            var locations = await locationRepository.GetLocations()
                .ProjectTo<LocationListDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return locations.Any()
                ? ServiceResult<List<LocationListDto>>.Ok(locations)
                : ServiceResult<List<LocationListDto>>.Fail("Hiçbir konum bulunamadı.");
        }

        public async Task<ServiceResult<LocationListDto>> GetByIdAsync(int id)
        {
            var location = await locationRepository.GetByIdAsync(id);
            if (location == null)
                return ServiceResult<LocationListDto>.Fail("Konum bulunamadı.");
            var dto = mapper.Map<LocationListDto>(location);
            return ServiceResult<LocationListDto>.Ok(dto);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateLocationDto updateLocationDto)
        {
            var location = await locationRepository.GetByIdAsync(id);
            if (location == null)
                return ServiceResult.Fail("Konum bulunamadı.");
            mapper.Map(updateLocationDto, location);
            location.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Konum başarıyla güncellendi.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var location = await locationRepository.GetByIdAsync(id);
            if (location == null)
                return ServiceResult.Fail("Konum bulunamadı.");
            if (location.DeletedAt != null)
                return ServiceResult.Fail("Konum zaten silinmiş.");
            location.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Konum başarıyla silindi.");
        }
    }
}