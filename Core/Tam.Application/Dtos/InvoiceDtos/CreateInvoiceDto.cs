using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.InvoiceDtos
{
    public class CreateInvoiceDto
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; } = false;
        public int? CurrencyId { get; set; }
        public string? PdfUrl { get; set; }
        public int? PaymentId { get; set; }
        public int? TourReservationId { get; set; }
        public int? HotelReservationId { get; set; }
        public int? TransferReservationId { get; set; }
    }
}
