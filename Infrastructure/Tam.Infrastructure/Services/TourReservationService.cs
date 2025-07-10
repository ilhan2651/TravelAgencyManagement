using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.TourReservationDtos;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Tam.Infrastructure.Services
{
    public class TourReservationService(
        ITourReservationRepository tourReservationRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper
    ) : ITourReservationService
    {
        public async Task<ServiceResult> CreateAsync(CreateTourReservationDto dto)
        {
            var entity = mapper.Map<TourReservation>(dto);
            entity.ReservationDate = DateTime.UtcNow;
            await tourReservationRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rezervasyon başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateTourReservationDto dto)
        {
            var entity = await tourReservationRepository.GetReservationWithDetailsAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Rezervasyon bulunamadı.");

            TourReservationFactory.Update(entity, dto);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rezervasyon başarıyla güncellendi.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await tourReservationRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Rezervasyon bulunamadı.");

            entity.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rezervasyon başarıyla silindi.");
        }

        public async Task<ServiceResult<List<ListTourReservationDto>>> GetAllAsync()
        {
            var list = await tourReservationRepository.GetAllWithDetails().ToListAsync();
            if (!list.Any())
                return ServiceResult<List<ListTourReservationDto>>.Fail("Kayıt bulunamadı.");
            var mapped = mapper.Map<List<ListTourReservationDto>>(list);
            return ServiceResult<List<ListTourReservationDto>>.Ok(mapped);
        }

        public async Task<ServiceResult<TourReservationDetailDto>> GetByIdAsync(int id)
        {
            var entity = await tourReservationRepository.GetReservationWithDetailsAsync(id);
            if (entity == null)
                return ServiceResult<TourReservationDetailDto>.Fail("Rezervasyon bulunamadı.");
            var dto = mapper.Map<TourReservationDetailDto>(entity);
            return ServiceResult<TourReservationDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult<TourReservationSearchResultDto>> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<TourReservationSearchResultDto>.Fail("Arama terimi boş olamaz.");

            var result = await tourReservationRepository
                .SearchByCustomerName(searchTerm.Trim().ToLower())
                .ProjectTo<TourReservationSearchResultDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result is null
                ? ServiceResult<TourReservationSearchResultDto>.Fail("Eşleşen rezervasyon bulunamadı.")
                : ServiceResult<TourReservationSearchResultDto>.Ok(result);
        }
    }
}
