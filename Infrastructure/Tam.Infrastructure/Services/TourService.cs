using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.TourDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Application.Factories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class TourService(
        ITourRepository tourRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
    ) : ITourService
    {
        public async Task<ServiceResult> CreateAsync(CreateTourDto dto)
        {
            var entity = mapper.Map<Tour>(dto);
            entity.CreatedAt = DateTime.UtcNow;
            await tourRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Tur başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<PagedResult<TourListDto>>> GetAllAsync(int page, int pageSize)
        {
            var query = tourRepository.GetAllTours();
            if (!query.Any())
                return ServiceResult<PagedResult<TourListDto>>.Fail("Tur bulunamadı.");

            var paged = await query.ProjectToPagedResultAsync<Tour, TourListDto>(
                mapper.ConfigurationProvider,
                page,
                pageSize);
            return ServiceResult<PagedResult<TourListDto>>.Ok(paged);
        }

        public async Task<ServiceResult<TourDetailDto>> GetByIdAsync(int id)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(id);
            if (tour == null)
                return ServiceResult<TourDetailDto>.Fail("Tur bulunamadı.");

            var dto = mapper.Map<TourDetailDto>(tour);
            return ServiceResult<TourDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult<List<TourSearchResultDto>>> SearchAsync(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return ServiceResult<List<TourSearchResultDto>>.Fail("Arama terimi boş olamaz.");
            var result = await tourRepository.SearchTours(term.Trim())
                .ProjectTo<TourSearchResultDto>(mapper.ConfigurationProvider)
                .ToListAsync();
            return result.Any()
                ? ServiceResult<List<TourSearchResultDto>>.Ok(result)
                : ServiceResult<List<TourSearchResultDto>>.Fail("Eşleşen tur bulunamadı.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var tour = await tourRepository.GetByIdAsync(id);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");
            if (tour.DeletedAt != null)
                return ServiceResult.Fail("Tur zaten silinmiş.");
            tour.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Tur başarıyla silindi.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateTourDto dto)
        {
            var tour = await tourRepository.GetByIdAsync(id);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");
            mapper.Map(dto, tour);
            tour.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Tur başarıyla güncellendi.");
        }

        public async Task<ServiceResult> AssignDriversAsync(int tourId, List<int> driverIds)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            foreach (var driverId in driverIds.Distinct())
            {
                bool exists = tour.TourDrivers?.Any(td => td.DriverId == driverId) == true;
                if (!exists)
                {
                    var entity = TourDriverFactory.Create(tourId, driverId);
                    tour.TourDrivers ??= [];
                    tour.TourDrivers.Add(entity);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Sürücüler başarıyla atandı.");
        }

        public async Task<ServiceResult> AssignVehiclesAsync(int tourId, List<int> vehicleIds)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            foreach (var vehicleId in vehicleIds.Distinct())
            {
                bool exists = tour.TourVehicles?.Any(tv => tv.VehicleId == vehicleId) == true;
                if (!exists)
                {
                    var entity = TourVehicleFactory.Create(tourId, vehicleId);
                    tour.TourVehicles ??= [];
                    tour.TourVehicles.Add(entity);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Araçlar başarıyla atandı.");
        }

        public async Task<ServiceResult> AssignHotelsAsync(int tourId, List<int> hotelIds)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            foreach (var hotelId in hotelIds.Distinct())
            {
                bool exists = tour.TourHotels?.Any(th => th.HotelId == hotelId) == true;
                if (!exists)
                {
                    var entity = TourHotelFactory.Create(tourId, hotelId);
                    tour.TourHotels ??= [];
                    tour.TourHotels.Add(entity);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Oteller başarıyla atandı.");
        }

        public async Task<ServiceResult> AssignRegionsAsync(int tourId, List<int> regionIds)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            foreach (var regionId in regionIds.Distinct())
            {
                bool exists = tour.TourRegions?.Any(tr => tr.RegionId == regionId) == true;
                if (!exists)
                {
                    var entity = TourRegionFactory.Create(tourId, regionId);
                    tour.TourRegions ??= [];
                    tour.TourRegions.Add(entity);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Bölgeler başarıyla atandı.");
        }

        public async Task<ServiceResult> RemoveDriverAsync(int tourId, int driverId)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            var toRemove = tour.TourDrivers?.FirstOrDefault(td => td.DriverId == driverId);
            if (toRemove == null)
                return ServiceResult.Fail("Bu sürücü zaten turda değil.");

            tour.TourDrivers!.Remove(toRemove);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Sürücü turdan kaldırıldı.");
        }

        public async Task<ServiceResult> RemoveVehicleAsync(int tourId, int vehicleId)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            var toRemove = tour.TourVehicles?.FirstOrDefault(tv => tv.VehicleId == vehicleId);
            if (toRemove == null)
                return ServiceResult.Fail("Bu araç zaten turda değil.");

            tour.TourVehicles!.Remove(toRemove);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Araç turdan kaldırıldı.");
        }

        public async Task<ServiceResult> RemoveHotelAsync(int tourId, int hotelId)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            var toRemove = tour.TourHotels?.FirstOrDefault(th => th.HotelId == hotelId);
            if (toRemove == null)
                return ServiceResult.Fail("Bu otel zaten turda değil.");

            tour.TourHotels!.Remove(toRemove);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Otel turdan kaldırıldı.");
        }

        public async Task<ServiceResult> RemoveRegionAsync(int tourId, int regionId)
        {
            var tour = await tourRepository.GetTourWithDetailsAsync(tourId);
            if (tour == null)
                return ServiceResult.Fail("Tur bulunamadı.");

            var toRemove = tour.TourRegions?.FirstOrDefault(tr => tr.RegionId == regionId);
            if (toRemove == null)
                return ServiceResult.Fail("Bu bölge zaten turda değil.");

            tour.TourRegions!.Remove(toRemove);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Bölge turdan kaldırıldı.");
        }
    }
}