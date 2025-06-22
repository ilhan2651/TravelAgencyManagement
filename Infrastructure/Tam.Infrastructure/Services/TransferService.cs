using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.Transfer;
using Tam.Application.Factories;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class TransferService(
        ITransferRepository transferRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork
        ) : ITransferService
    {
        public async Task<ServiceResult> AssignDriversAsync(int transferId, List<int> driverIds)
        {
            var transfer = await transferRepository.GetTransferWithDetailsAsync(transferId);
            if (transfer == null)
                return ServiceResult.Fail("Transfer bulunamadı.");

            foreach (var driverId in driverIds.Distinct())
            {
                bool exists = transfer.DriverTransfers.Any(dt => dt.DriverId == driverId);
                if (!exists)
                {
                    var entity = DriverTransferFactory.Create(transferId, driverId);
                    transfer.DriverTransfers.Add(entity);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Şoförler başarıyla atandı.");
        }

        public async Task<ServiceResult> AssignVehiclesAsync(int transferId, List<int> vehicleIds)
        {
            var transfer = await transferRepository.GetTransferWithDetailsAsync(transferId);
            if (transfer == null)
                return ServiceResult.Fail("Transfer bulunamadı.");

            foreach (var vehicleId in vehicleIds.Distinct())
            {
                bool exists = transfer.TransferVehicles.Any(tv => tv.VehicleId == vehicleId);
                if (!exists)
                {
                    var entity = TransferVehicleFactory.Create(transferId, vehicleId);
                    transfer.TransferVehicles.Add(entity);
                }
            }

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Araçlar başarıyla atandı.");
        }

        public async  Task<ServiceResult> CreateAsync(CreateTransferDto dto)
        {
            var entity = mapper.Map<Transfer>(dto);
            entity.CreatedAt = DateTime.UtcNow;

            await transferRepository.AddAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Transfer başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<PagedResult<TransferListDto>>> GetAllAsync(int page, int pageSize)
        {
            var query = transferRepository.GetAllTransfers();
            if (!query.Any())
                return ServiceResult<PagedResult<TransferListDto>>.Fail("Hiçbir transfer bulunamadı.");

            var paged = await query.ProjectToPagedResultAsync<Transfer, TransferListDto>(mapper.ConfigurationProvider, page, pageSize);
            return ServiceResult<PagedResult<TransferListDto>>.Ok(paged);
        }

        public async  Task<ServiceResult<TransferDetailDto>> GetByIdAsync(int id)
        {
            var transfer = await transferRepository.GetTransferWithDetailsAsync(id);
            if (transfer == null)
                return ServiceResult<TransferDetailDto>.Fail("Transfer bulunamadı.");

            var dto = mapper.Map<TransferDetailDto>(transfer);
            return ServiceResult<TransferDetailDto>.Ok(dto);
        }

        public async  Task<ServiceResult> RemoveDriverAsync(int transferId, int driverId)
        {
            var transfer = await transferRepository.GetTransferWithDetailsAsync(transferId);
            if (transfer == null)
                return ServiceResult.Fail("Transfer bulunamadı.");

            var driverToRemove = transfer.DriverTransfers?.FirstOrDefault(dt => dt.DriverId == driverId);
            if (driverToRemove == null)
                return ServiceResult.Fail("Bu sürücü zaten transferde değil.");

            transfer.DriverTransfers?.Remove(driverToRemove);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Sürücü transferden kaldırıldı.");
        }

        public async  Task<ServiceResult> RemoveVehicleAsync(int transferId, int vehicleId)
        {
            var transfer = await transferRepository.GetTransferWithDetailsAsync(transferId);
            if (transfer == null)
                return ServiceResult.Fail("Transfer bulunamadı.");

            var vehicleToRemove = transfer.TransferVehicles.FirstOrDefault(tv => tv.VehicleId == vehicleId);
            if (vehicleToRemove == null)
                return ServiceResult.Fail("Bu araç zaten transferde değil.");

            transfer.TransferVehicles.Remove(vehicleToRemove);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Araç transferden kaldırıldı.");
        }

        public async Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var transfer = await transferRepository.GetByIdAsync(id);
            if (transfer == null)
                return ServiceResult.Fail("Transfer bulunamadı.");

            if (transfer.DeletedAt != null)
                return ServiceResult.Fail("Transfer zaten silinmiş.");

            transfer.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Transfer başarıyla silindi.");
        }

        public async  Task<ServiceResult> UpdateAsync(int id, UpdateTransferDto dto)
        {
            var transfer = await transferRepository.GetByIdAsync(id);
            if (transfer == null)
                return ServiceResult.Fail("Transfer bulunamadı.");

            mapper.Map(dto, transfer);
            transfer.UpdatedAt = DateTime.UtcNow;

            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Transfer başarıyla güncellendi.");
        }
    }
}
