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
using Tam.Application.Dtos.VehicleDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class VehicleService(IVehicleRepository vehicleRepository, IMapper mapper, IUnitOfWork unitOfWork)  : IVehicleService
    {
        public async Task<ServiceResult> CreateAsync(CreateVehicleDto createDto)
        {
            var vehicle = mapper.Map<Vehicle>(createDto);
            vehicle.CreatedAt = DateTime.UtcNow;

            await vehicleRepository.AddAsync(vehicle);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Araç başarıyla oluşturuldu.");
        }
        public async Task<ServiceResult<PagedResult<VehicleListDto>>> GetAllAsync(int page, int pageSize)
        {
            var query = vehicleRepository.GetAllVehicles();
            if (!query.Any())
                return ServiceResult<PagedResult<VehicleListDto>>.Fail("Araç bulunamadı.");

            var paged = await query.ProjectToPagedResultAsync<Vehicle, VehicleListDto>(
                mapper.ConfigurationProvider,
                page,
                pageSize);

            return ServiceResult<PagedResult<VehicleListDto>>.Ok(paged);
        }
        public async Task<ServiceResult<VehicleDetailDto>> GetByIdAsync(int id)
        {
            var vehicle = await vehicleRepository.GetVehicleWithDetails(id);
            if (vehicle == null)
                return ServiceResult<VehicleDetailDto>.Fail("Araç bulunamadı.");

            var dto = mapper.Map<VehicleDetailDto>(vehicle);
            return ServiceResult<VehicleDetailDto>.Ok(dto);
        }
        public async Task<ServiceResult<List<VehicleSearchResultDto>>> SearchAsync(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return ServiceResult<List<VehicleSearchResultDto>>.Fail("Arama terimi boş olamaz.");

            var result = await vehicleRepository.SearchVehicles(term.Trim())
                .ProjectTo<VehicleSearchResultDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return result.Any()
                ? ServiceResult<List<VehicleSearchResultDto>>.Ok(result)
                : ServiceResult<List<VehicleSearchResultDto>>.Fail("Eşleşen araç bulunamadı.");
        }
        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var vehicle = await vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
                return ServiceResult.Fail("Araç bulunamadı.");
            if (vehicle.DeletedAt != null)
                return ServiceResult.Fail("Araç zaten silinmiş.");

            vehicle.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Araç başarıyla silindi.");
        }
        public async Task<ServiceResult> UpdateAsync(int id, UpdateVehicleDto updateDto)
        {
            var vehicle = await vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
                return ServiceResult.Fail("Araç bulunamadı.");

            mapper.Map(updateDto, vehicle);
            vehicle.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Araç güncellendi.");
        }
    }
}
