using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Common.Wrappers;
using Tam.Application.Dtos.Common;
using Tam.Application.Dtos.InvoiceDtos;
using Tam.Application.Interfaces.Infrastructure;
using Tam.Application.Interfaces.Repositories;
using Tam.Application.Interfaces.Services;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;

namespace Tam.Infrastructure.Services
{
    public class InvoiceService
        (
        IInvoiceRepository invoiceRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
        ) : IInvoiceService
    {
        public async Task<ServiceResult> CreateAsync(CreateInvoiceDto createDto)
        {
           var invoice = mapper.Map<Invoice>(createDto);
            invoice.CreatedAt = DateTime.UtcNow;
            var (subTotal, error) = await invoiceRepository.GetReservationPriceAsync(createDto, invoice);
            if (error is not null)
                return ServiceResult.Fail(error);
            invoice.SubTotal = subTotal;
            invoice.TaxAmount = subTotal * 0.18m;
            invoice.TotalAmount = subTotal + invoice.TaxAmount;


            await invoiceRepository.AddAsync(invoice);
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Fatura başarıyla oluşturuldu.");
        }

        public async Task<ServiceResult<PagedResult<ListInvoiceDto>>> GetAllAsync()
        {
            var query = invoiceRepository.GetAllInvoice();
            if(!query.Any())
                return ServiceResult<PagedResult<ListInvoiceDto>>.Fail("Hiçbir fatura bulunamadı.");
            var pagedResult= await query
                .ProjectToPagedResultAsync<Invoice, ListInvoiceDto>(mapper.ConfigurationProvider, 1, 10);
            return ServiceResult<PagedResult<ListInvoiceDto>>.Ok(pagedResult);
        }

        public async Task<ServiceResult<InvoiceDetailDto>> GetByIdAsync(int id)
        {
            var invoice = await invoiceRepository.GetInvoiceWithDetails(id);
            if (invoice == null)
                return ServiceResult<InvoiceDetailDto>.Fail("Fatura bulunamadı.");

            var dto = mapper.Map<InvoiceDetailDto>(invoice);
            return ServiceResult<InvoiceDetailDto>.Ok(dto);
        }

        public async Task<List<SearchInvoiceDto>> SearchInvoicesAsync(string? term, DateTime? startDate, DateTime? endDate)
        {
            var query= invoiceRepository.GetAllInvoice();
            query = invoiceRepository.FilterByDate(startDate, endDate);
            query = invoiceRepository.FilterByTerm(query, term);
            var result = await query
         .Select(i => new SearchInvoiceDto
         {
             InvoiceNumber = i.InvoiceNumber,
             CustomerName = i.Customer.FullName,
             InvoiceDate = i.InvoiceDate,
             TotalAmount = i.TotalAmount,
             IsPaid = i.IsPaid
         })
         .ToListAsync();
            return result;
        }

        public async  Task<ServiceResult> SoftDeleteAsync(int id)
        {
            var invoice = await invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
               return ServiceResult.Fail("Fatura bulunamadı.");
            if(invoice.DeletedAt != null)
                return ServiceResult.Fail("Fatura zaten silinmiş.");
            invoice.DeletedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Fatura başarıyla silindi.");
            
        }

        public async Task<ServiceResult> UpdateAsync(int id, UpdateInvoiceDto updateDto)
        {
            var invoice = await invoiceRepository.GetByIdAsync(id);
            if (invoice == null)
                return ServiceResult.Fail("Fatura bulunamadı.");
            mapper.Map(updateDto, invoice);
            invoice.UpdatedAt = DateTime.UtcNow;
            await unitOfWork.SaveChangesAsync();
            return ServiceResult.Ok("Fatura başarıyla güncellendi.");



        }
    }
}
