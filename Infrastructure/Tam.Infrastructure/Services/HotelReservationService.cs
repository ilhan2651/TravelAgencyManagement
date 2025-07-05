using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.HotelReservationDtos;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class HotelReservationService(
          IHotelReservationRepository hotelReservationRepository,
          IUnitOfWork unitOfWork,
          IMapper mapper,
          IHotelRoomOptionRepository hotelRoomOptionRepository,
          IRabbitMqPublisher rabbitMqPublisher,
          IDiscountRepository discountRepository
           
      ) : IHotelReservationService
    {
        public async Task<ServiceResult> CreateAsync(CreateHotelReservationDto dto)
        {
            var discount = dto.DiscountId.HasValue
                ? await discountRepository.GetByIdAsync(dto.DiscountId.Value)
                : null;

            var reservedRoomDetails = new List<ReservedRoomDetailDto>();

            foreach (var room in dto.ReservedRooms)
            {
                var roomOption = await hotelRoomOptionRepository.GetOptionByIdAsync(room.HotelRoomOptionId);
                if (roomOption == null)
                    return ServiceResult.Fail("Oda seçeneği bulunamadı.");

                reservedRoomDetails.Add(new ReservedRoomDetailDto
                {
                    RoomTypeName = roomOption.RoomType.Name,
                    PricePerNight = roomOption.PricePerNight,
                    Quantity = room.Quantity
                });
            }

            var reservation = HotelReservationFactory.Create(dto, reservedRoomDetails, discount);

            await hotelReservationRepository.AddAsync(reservation);
            await unitOfWork.SaveChangesAsync();

            var fullReservation = await hotelReservationRepository.GetReservationByIdAsync(reservation.Id);
            var message = ReservationEmailMessageFactory.Create(fullReservation);
           await rabbitMqPublisher.PublishAsync("reservation-email", message);

            return ServiceResult.Ok("Rezervasyon başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await hotelReservationRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Rezervasyon bulunamadı.");

            entity.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Rezervasyon başarıyla silindi.");
        }

        public async Task<ServiceResult<List<ListHotelReservationDto>>> GetAllAsync()
        {
            var list = await hotelReservationRepository.GetAllForList().ToListAsync();
            var mapped = mapper.Map<List<ListHotelReservationDto>>(list);
            return ServiceResult<List<ListHotelReservationDto>>.Ok(mapped);

        }

        public async Task<ServiceResult<List<ListHotelReservationDto>>> GetByDateRangeAsync(DateTime start, DateTime end)
        {
            var list = await hotelReservationRepository.GetByDateRange(start, end).ToListAsync();
            var mapped = mapper.Map<List<ListHotelReservationDto>>(list);
            return ServiceResult<List<ListHotelReservationDto>>.Ok(mapped);
        }

        public async Task<ServiceResult<HotelReservationDetailDto>> GetByIdAsync(int id)
        {
            var entity = await hotelReservationRepository.GetReservationByIdAsync(id);
            if (entity == null)
                return ServiceResult<HotelReservationDetailDto>.Fail("Rezervasyon bulunamadı.");

            var dto = mapper.Map<HotelReservationDetailDto>(entity);
            return ServiceResult<HotelReservationDetailDto>.Ok(dto);
        }

        public async Task<ServiceResult<List<HotelReservationSearchResultDto>>> SearchByCustomerNameAsync(string name)
        {
            var list = await hotelReservationRepository.SearchByCustomerName(name).ToListAsync();
            var mapped = mapper.Map<List<HotelReservationSearchResultDto>>(list);
            return ServiceResult<List<HotelReservationSearchResultDto>>.Ok(mapped);
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateHotelReservationDto dto)
        {
            var entity = await hotelReservationRepository.GetByIdAsync(id);
            if (entity is null)
                return ServiceResult.Fail("Rezervasyon bulunamadı.");

            var discount = dto.DiscountId.HasValue
                ? await discountRepository.GetByIdAsync(dto.DiscountId.Value)
                : null;

            var reservedRoomDetails = new List<ReservedRoomDetailDto>();

            foreach (var room in dto.ReservedRooms)
            {
                var roomOption = await hotelRoomOptionRepository.GetByIdAsync(room.HotelRoomOptionId);
                if (roomOption == null)
                    return ServiceResult.Fail("Oda seçeneği bulunamadı.");

                reservedRoomDetails.Add(new ReservedRoomDetailDto
                {
                    RoomTypeName = roomOption.RoomType.Name,
                    PricePerNight = roomOption.PricePerNight,
                    Quantity = room.Quantity
                });
            }

            HotelReservationFactory.Update(entity, dto, reservedRoomDetails, discount);

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Rezervasyon başarıyla güncellendi.");
        }
    }
}
