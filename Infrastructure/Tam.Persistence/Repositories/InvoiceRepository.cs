using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.InvoiceDtos;
using Tam.Application.Interfaces.Repositories;
using Tam.Domain.Entities;
using Tam.Infrastructure.Extensions;
using Tam.Persistence.Context;

namespace Tam.Persistence.Repositories
{
    public class InvoiceRepository(TamDbContext context) : GenericRepository<Invoice>(context), IInvoiceRepository
    {
        public IQueryable<Invoice> FilterByDate(DateTime? start, DateTime? end)
        {
            var query = context.Invoices.AsQueryable();
            if(start.HasValue)
            {
                query = query.Where(i => i.InvoiceDate >= start.Value);
            }
            if(end.HasValue)
            {
                   query = query.Where(i => i.InvoiceDate <= end.Value);
            }
            return query;
        }

        public IQueryable<Invoice> FilterByTerm(IQueryable<Invoice> query, string? term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return query;
            term= term.Trim().ToLower();
            return query.Where(i =>
        EF.Functions.ILike(PgExtensions.Unaccent(i.InvoiceNumber), $"%{term}%") ||
        EF.Functions.ILike(PgExtensions.Unaccent(i.Customer.FullName), $"%{term}%") ||
        EF.Functions.ILike(PgExtensions.Unaccent(i.TourReservation.Tour.Name), $"%{term}%") ||
        EF.Functions.ILike(PgExtensions.Unaccent(i.HotelReservation.Hotel.Name), $"%{term}%") ||
        EF.Functions.ILike(PgExtensions.Unaccent(i.TransferReservation.Transfer.Name), $"%{term}%"))
                .OrderByDescending(e=>e.DeletedAt==null)
                .ThenBy(e=>e.InvoiceDate);
        }

        public  IQueryable<Invoice> GetAllInvoice()
        {
            return context.Invoices
                .Include(i => i.Customer)
                .Include(i => i.Payment)
                .OrderByDescending(i => i.DeletedAt == null)
                .ThenBy(i => i.InvoiceDate);
               
        }

        public async Task<Invoice> GetInvoiceWithDetails(int id)
        {
            return await context.Invoices
               .Include(i => i.Customer)
               .Include(i => i.Payment)
               .Include(i => i.TourReservation)
              .ThenInclude(tr => tr.Tour)
              .Include(i => i.HotelReservation)
              .ThenInclude(hr => hr.Hotel)
              .Include(i => i.TransferReservation)
              .ThenInclude(tr => tr.Transfer)
               .OrderByDescending(i => i.DeletedAt == null)
               .ThenBy(i => i.InvoiceDate)
               .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<(decimal price, string? error)> GetReservationPriceAsync(CreateInvoiceDto dto, Invoice invoice)
        {
            if (dto.TourReservationId.HasValue)
            {
                var tour = await context.TourReservations.FindAsync(dto.TourReservationId.Value);
                if (tour is null) return (0, "Tur rezervasyonu bulunamadı.");
                invoice.TourReservation = tour;
                return (tour.TotalPrice, null);
            }

            if (dto.HotelReservationId.HasValue)
            {
                var hotel = await context.HotelReservations.FindAsync(dto.HotelReservationId.Value);
                if (hotel is null) return (0, "Otel rezervasyonu bulunamadı.");
                invoice.HotelReservation = hotel;
                return (hotel.TotalPrice, null);
            }

            if (dto.TransferReservationId.HasValue)
            {
                var transfer = await context.TransferReservations.FindAsync(dto.TransferReservationId.Value);
                if (transfer is null) return (0, "Transfer rezervasyonu bulunamadı.");
                invoice.TransferReservation = transfer;
                return (transfer.TotalPrice, null);
            }

            return (0, "Hiçbir rezervasyon tipi seçilmedi.");
        }
    }
}
