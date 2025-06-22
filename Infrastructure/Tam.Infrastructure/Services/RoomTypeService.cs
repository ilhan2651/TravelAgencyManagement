using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.RoomType;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RoomTypeService(IRoomTypeRepository repo, IUnitOfWork uow, IMapper mapper)
        {
            _roomTypeRepository = repo;
            _unitOfWork = uow;
            _mapper = mapper;
        }

        public async Task<ServiceResult> CreateAsync(CreateRoomTypeDto dto)
        {
            var entity = _mapper.Map<RoomType>(dto);
            await _roomTypeRepository.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Oda tipi başarıyla eklendi.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateRoomTypeDto dto)
        {
            var entity = await _roomTypeRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Oda tipi bulunamadı.");
            _mapper.Map(dto, entity);
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Oda tipi başarıyla güncellendi.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var entity = await _roomTypeRepository.GetByIdAsync(id);
            if (entity == null)
                return ServiceResult.Fail("Oda tipi bulunamadı.");
            entity.DeletedAt = DateTime.UtcNow;
            await _unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Oda tipi başarıyla silindi.");
        }

        public async Task<ServiceResult<List<ListRoomTypeDto>>> GetAllAsync()
        {
            var list = await _roomTypeRepository.GetAllRoomTypes().ToListAsync();
            var dtoList = _mapper.Map<List<ListRoomTypeDto>>(list);
            return ServiceResult<List<ListRoomTypeDto>>.Ok(dtoList);
        }
    }

}
