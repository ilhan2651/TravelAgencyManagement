using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Aprantee;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.CustomerDtos;
using Tam.Application.Dtos.Supplier;

namespace Tam.Application.Interfaces.Services
{
    public interface ISupplierService
    {
        Task<ServiceResult<List<SupplierListDto>>> GetAllSuppliers();
        Task<ServiceResult<SupplierListDto>> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CreateSupplierDto createSupplierDto);
        Task<ServiceResult> UpdateAsync(int id, UpdateSupplierDto updateSupplierDto);
        Task<ServiceResult> SoftDeleteSupplierAsync(int id);
        Task<ServiceResult<List<SupplierListDto>>> SearchSupplierAsync(string searchTerm);

    }
}
