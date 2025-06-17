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
using Tam.Application.Dtos.CustomerDtos;
using Tam.Application.Dtos.Supplier;
using Tam.Application.Dtos.SupplierDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Services
{
    public class SupplierService(ISupplierRepository supplierRepository, IMapper mapper, IUnitOfWork unitOfWork) : ISupplierService
    {
        public async Task<ServiceResult> CreateAsync(CreateSupplierDto createSupplierDto)
        {
            var supplier = mapper.Map<Supplier>(createSupplierDto);
            supplier.CreatedAt = DateTime.UtcNow;

            await supplierRepository.AddAsync(supplier);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Ok("Tedarikçi başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<List<SupplierListDto>>> GetAllSuppliers()
        {
            var suppliers = await supplierRepository.GetAllSuppliers();
            if (suppliers == null)
                return ServiceResult<List<SupplierListDto>>.Fail("Hiçbir tedarikçi bulunamadı.");
            var result = mapper.Map<List<SupplierListDto>>(suppliers);
            return ServiceResult<List<SupplierListDto>>.Ok(result);



        }

        public async Task<ServiceResult<SupplierListDto>> GetByIdAsync(int id)
        {
            var supplier =await supplierRepository.GetByIdAsync(id);
            if (supplier == null)
                return ServiceResult<SupplierListDto>.Fail("Tedarikçi bulunamadı.");
            var result = mapper.Map<SupplierListDto>(supplier);
            return ServiceResult<SupplierListDto>.Ok(result);

        }

        public async Task<ServiceResult<List<SupplierSearchResultDto>>> SearchSupplierAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return ServiceResult<List<SupplierSearchResultDto>>.Fail("Arama terimi boş olamaz.");
            var query = supplierRepository.SearchSuppliers(searchTerm);
            var result = await query
                   .ProjectTo<SupplierSearchResultDto>(mapper.ConfigurationProvider)
                   .ToListAsync();
            return result.Any()
                  ? ServiceResult<List<SupplierSearchResultDto>>.Ok(result)
                  : ServiceResult<List<SupplierSearchResultDto>>.Fail("Eşleşen tedarikçi bulunamadı.");
        }

        public async Task<ServiceResult> SoftDeleteSupplierAsync(int id)
        {
            var supplier =await supplierRepository.GetByIdAsync(id);
            if (supplier == null)
                return ServiceResult.Fail("Tedarikçi bulunamadı.");
            if(supplier.DeletedAt!=null)
                return ServiceResult.Fail("Tedarikçi zaten silinmiş.");
            supplier.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Tedarikçi başarıyla silindi.");
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateSupplierDto updateSupplierDto)
        {
            var supplier = await supplierRepository.GetByIdAsync(id);
            if (supplier == null)
                return ServiceResult.Fail("Tedarikçi bulunamadı.");
            mapper.Map(updateSupplierDto, supplier);
            supplier.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Tedarikçi başarıyla güncellendi.");
        }
    }
}
