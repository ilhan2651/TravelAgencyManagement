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
using Tam.Application.Dtos.DriverDto;
using Tam.Application.Dtos.DriverDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class DriverService(IDriverRepository driverRepository, IMapper mapper, IUnitOfWork unitOfWork) : IDriverService
    {
        public async Task<ServiceResult> CreateAsync(CreateDriverDto createDriverDto)
        {
            var driver = mapper.Map<Driver>(createDriverDto);
            driver.CreatedAt = DateTime.UtcNow;

            await driverRepository.AddAsync(driver);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Sürücü başarıyla oluşturuldu.");
        }

        

        public async Task<ServiceResult<PagedResult<DriverListDto>>> GetAllAsync(int page, int pageSize)
        {
            var query = driverRepository.GetAllDrivers();
            if (!query.Any())
                return ServiceResult<PagedResult<DriverListDto>>.Fail("Hiçbir sürücü bulunamadı.");
            var pagedResult = await query.ProjectToPagedResultAsync<Driver, DriverListDto>(
                mapper.ConfigurationProvider,
                page,
                pageSize
            );
            return ServiceResult<PagedResult<DriverListDto>>.Ok(pagedResult);
        }

       

        public async Task<ServiceResult<DriverDetailDto>> GetByIdAsync(int id)
        {
            var driver = await driverRepository.GetDriverWithTransfersAndTours(id);
            if (driver == null) 
                return ServiceResult<DriverDetailDto>.Fail("Sürücü bulunamadı.");
            var driverDetailDto = mapper.Map<DriverDetailDto>(driver);
            return ServiceResult<DriverDetailDto>.Ok(driverDetailDto);
   
        }

        public async Task<ServiceResult<List<DriverSearchResultDto>>> SearchAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<List<DriverSearchResultDto>>.Fail("Arama terimi boş olamaz.");

            var result = await driverRepository.SearchDrivers(searchTerm.Trim())
                
                .ProjectTo<DriverSearchResultDto>(mapper.ConfigurationProvider)
                .ToListAsync();

            return result.Any()
                ? ServiceResult<List<DriverSearchResultDto>>.Ok(result)
                : ServiceResult<List<DriverSearchResultDto>>.Fail("Eşleşen sürücü bulunamadı.");
        }

        public async Task<ServiceResult> SoftDeleteDriverAsync(int id)
        {
            var driver =await driverRepository.GetByIdAsync(id);
            if (driver == null)
                return ServiceResult.Fail("Sürücü bulunamadı.");
            if (driver.DeletedAt != null)
                return ServiceResult.Fail("Sürücü zaten silinmiş.");
            driver.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Sürücü başarıyla silindi.");


        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateDriverDto updateDriverDto)
        {
           var driver = await driverRepository.GetByIdAsync(id);
          if( driver == null)
                return ServiceResult.Fail("Sürücü bulunamadı.");
          mapper.Map(updateDriverDto, driver);
            driver.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Sürücü bilgileri başarıyla güncellendi.");

            
        }
    }
}
