using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.InvoiceDtos;
using Tam.Domain.Entities;

namespace Tam.Application.Interfaces.Repositories
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        IQueryable<Invoice> GetAllInvoice();
        Task<Invoice?> GetInvoiceWithDetails(int id);
         IQueryable<Invoice> FilterByDate(DateTime? start, DateTime? end);

        IQueryable<Invoice> FilterByTerm(IQueryable<Invoice> query, string? term);
         Task<(decimal price, string? error)> GetReservationPriceAsync(CreateInvoiceDto dto, Invoice invoice);


    }
}
