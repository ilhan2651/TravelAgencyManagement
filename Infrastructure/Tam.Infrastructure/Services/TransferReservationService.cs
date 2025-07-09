using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.TransferReservationDtos;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class TransferReservationService(
        ITransferReservationRepository transferReservationRepository,
        IUnitOfWork unitOfWork,
        IRabbitMqPublisher rabbitMqPublisher,

        IMapper mapper
    ) : ITransferReservationService
    {
        public async Task<ServiceResult> CreateAsync(CreateTransferReservationDto dto)
        {
            var entity = mapper.Map<TransferReservation>(dto);
            entity.ReservationDate = DateTime.UtcNow;

            await transferReservationRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();

            var fullReservation = await transferReservationRepository.GetReservationWithDetailsAsync(entity.Id);
            var message = TransferReservationEmailMessageFactory.Create(fullReservation);
            Console.WriteLine($"📤 Mesaj gönderiliyor → {JsonSerializer.Serialize(message)}");

            await rabbitMqPublisher.PublishAsync("transfer-reservation-email", message);
            return ServiceResult.Ok("Rezervasyon başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateTransferReservationDto dto)
        {
            var entity = await transferReservationRepository.GetReservationWithDetailsAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Rezervasyon bulunamadı.");

            TransferReservationFactory.Update(entity, dto);


            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rezervasyon başarıyla güncellendi.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await transferReservationRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Rezervasyon bulunamadı.");

            entity.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Rezervasyon başarıyla silindi.");
        }

        public async Task<ServiceResult<List<ListTransferReservationDto>>> GetAllAsync()
        {
            var list = await transferReservationRepository.GetAllWithGuests().ToListAsync();
            if (!list.Any())
                return ServiceResult<List<ListTransferReservationDto>>.Fail("Kayıt bulunamadı.");

            var mapped = mapper.Map<List<ListTransferReservationDto>>(list);
            return ServiceResult<List<ListTransferReservationDto>>.Ok(mapped);
        }

        public async Task<ServiceResult<TransferReservationDetailDto>> GetByIdAsync(int id)
        {
            var entity = await transferReservationRepository.GetReservationWithDetailsAsync(id);
            if (entity == null)
                return ServiceResult<TransferReservationDetailDto>.Fail("Rezervasyon bulunamadı.");

            var dto = mapper.Map<TransferReservationDetailDto>(entity);
            return ServiceResult<TransferReservationDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult<TransferReservationSearchResultDto>> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<TransferReservationSearchResultDto>.Fail("Arama terimi boş olamaz.");

            var result = await transferReservationRepository
                .SearchByCustomerName(searchTerm.Trim().ToLower())
                .ProjectTo<TransferReservationSearchResultDto>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return result is null
                ? ServiceResult<TransferReservationSearchResultDto>.Fail("Eşleşen rezervasyon bulunamadı.")
                : ServiceResult<TransferReservationSearchResultDto>.Ok(result);
        }

    }
}
