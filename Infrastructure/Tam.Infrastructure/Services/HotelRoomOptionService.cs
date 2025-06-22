using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.HotelRoomOptionDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class HotelRoomOptionService(
        IHotelRoomOptionRepository hotelRoomOptionRepository,
         IUnitOfWork unitOfWork,
         IMapper mapper) : IHotelRoomOptionService
    {
        public async Task<ServiceResult> CreateAsync(CreateHotelRoomOptionDto dto)
        {
            var entity = mapper.Map<HotelRoomOption>(dto);
            await hotelRoomOptionRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Otel oda seçeneği başarıyla eklendi.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateHotelRoomOptionDto dto)
        {
            var entity = await hotelRoomOptionRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Oda seçeneği bulunamadı.");

            mapper.Map(dto, entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Oda seçeneği başarıyla güncellendi.");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await hotelRoomOptionRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Oda seçeneği bulunamadı.");

            entity.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Oda seçeneği başarıyla silindi.");
        }

        public async Task<ServiceResult<List<ListHotelRoomOptionDto>>> GetAllAsync()
        {
            var list = await hotelRoomOptionRepository.GetAllOptions().ToListAsync();
            var mapped = mapper.Map<List<ListHotelRoomOptionDto>>(list);
            return ServiceResult<List<ListHotelRoomOptionDto>>.Ok(mapped);
        }


        public async Task<ServiceResult<ListHotelRoomOptionDto>> GetByIdAsync(int id)
        {
            var entity = await hotelRoomOptionRepository.GetOptionByIdAsync(id);
              

            if (entity == null)
                return ServiceResult<ListHotelRoomOptionDto>.Fail("Oda seçeneği bulunamadı.");

            var dto = mapper.Map<ListHotelRoomOptionDto>(entity);
            return ServiceResult<ListHotelRoomOptionDto>.Ok(dto);
        }
    }

}
