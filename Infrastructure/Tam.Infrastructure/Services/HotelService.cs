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
using Tam.Application.Dtos.HotelDtos;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class HotelService(
     IHotelRepository hotelRepository,
     IMapper mapper,
     IUnitOfWork unitOfWork) : IHotelService
    {
        public async Task<ServiceResult> CreateAsync(CreateHotelDto dto)
        {
            var hotel = mapper.Map<Hotel>(dto);
            hotel.CreatedAt = DateTime.UtcNow;

            await hotelRepository.AddAsync(hotel);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Otel başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<PagedResult<ListHotelDto>>> GetAllAsync(int page, int pageSize)
        {
            var query =  hotelRepository.GetAllHotels();

            if (!query.Any())
                return ServiceResult<PagedResult<ListHotelDto>>.Fail("Hiçbir otel bulunamadı.");

            var pagedResult = await query
                .ProjectToPagedResultAsync<Hotel, ListHotelDto>(mapper.ConfigurationProvider, page, pageSize);

            return ServiceResult<PagedResult<ListHotelDto>>.Ok(pagedResult);
        }

        public async Task<ServiceResult<HotelDetailDto>> GetByIdAsync(int id)
        {
            var hotel = await hotelRepository.GetHotelWithFacilities(id);

            if (hotel == null)
                return ServiceResult<HotelDetailDto>.Fail("Otel bulunamadı.");

            var dto = mapper.Map<HotelDetailDto>(hotel);
            return ServiceResult<HotelDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult<List<HotelSearchResultDto>>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<List<HotelSearchResultDto>>.Fail("Arama terimi boş olamaz.");

            var results = await hotelRepository
                .SearchHotels(searchTerm.Trim().ToLower())
                .ProjectTo<HotelSearchResultDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return results.Any()
                ? ServiceResult<List<HotelSearchResultDto>>.Ok(results)
                : ServiceResult<List<HotelSearchResultDto>>.Fail("Eşleşen otel bulunamadı.");
        }

        public async Task<ServiceResult> AssignFacilitiesAsync(int hotelId, List<int> facilityIds)
        {
            var hotel = await hotelRepository.GetHotelWithFacilities(hotelId);
            if (hotel == null)
                return ServiceResult.Fail("Otel bulunamadı.");


            foreach (var facilityId in facilityIds.Distinct())
            {
                bool alreadyExists = hotel.HotelFacilities.Any(hf => hf.FacilityId == facilityId);
                if (!alreadyExists)
                {
                    var hotelFacility = HotelFacilityFactory.Create(hotel.Id, facilityId);
                    hotel.HotelFacilities.Add(hotelFacility);
                }
            }


            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Otele özellikler başarıyla atandı.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateHotelDto dto)
        {
            var hotel = await hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return ServiceResult.Fail("Otel bulunamadı.");

            mapper.Map(dto, hotel);
            hotel.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Otel başarıyla güncellendi.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var hotel = await hotelRepository.GetByIdAsync(id);
            if (hotel == null)
                return ServiceResult.Fail("Otel bulunamadı.");

            if (hotel.DeletedAt != null)
                return ServiceResult.Fail("Otel zaten silinmiş.");

            hotel.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Otel başarıyla silindi.");
        }

        public async  Task<ServiceResult> RemoveFacilityAsync(int hotelId, int facilityId)
        {
            var hotel = await hotelRepository.GetHotelWithFacilities(hotelId);
            if (hotel == null)
                return ServiceResult.Fail("Otel bulunamadı.");
            var facilityToRemove = hotel.HotelFacilities
             .FirstOrDefault(hf => hf.FacilityId == facilityId);
            if (facilityToRemove == null)
                return ServiceResult.Fail("Bu özellik zaten bu otele ait değil.");
            hotel.HotelFacilities.Remove(facilityToRemove);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Özellik otelden başarıyla kaldırıldı.");
        }
    }

}
