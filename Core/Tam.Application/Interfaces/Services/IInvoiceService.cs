using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.InvoiceDtos;
using Tam.Application.Dtos.Language;

namespace Tam.Application.Interfaces.Services
{
    public interface IInvoiceService 
    {
        Task<ServiceResult> CreateAsync(CreateInvoiceDto createDto);
        Task<ServiceResult<InvoiceDetailDto>> GetByIdAsync(int id);
        Task<ServiceResult<PagedResult<ListInvoiceDto>>> GetAllAsync();
        Task<ServiceResult> UpdateAsync(int id, UpdateInvoiceDto updateDto);
        Task<ServiceResult> SoftDeleteAsync(int id);
        Task<List<SearchInvoiceDto>> SearchInvoicesAsync( string? term, DateTime? startDate, DateTime? endDate);

    }
}
