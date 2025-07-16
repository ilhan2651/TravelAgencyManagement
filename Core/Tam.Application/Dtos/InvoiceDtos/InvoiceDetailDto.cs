using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.InvoiceDtos
{
    public class InvoiceDetailDto
    {
        public string InvoiceNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; } 
        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }

        public bool IsPaid { get; set; } = false;
        public int? CurrencyId { get; set; }
        public string? PdfUrl { get; set; }
        public int? PaymentId { get; set; }
        public string? TourName { get; set; }
        public string? HotelName { get; set; }
        public string? TransferName { get; set; }
        public DateTime CreatedAt{ get; set; }
        public DateTime UpdatedAt{ get; set; }
        public DateTime DeletedAt{ get; set; }
    }
}
