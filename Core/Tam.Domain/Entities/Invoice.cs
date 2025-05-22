using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class Invoice
    {
        public int Id { get; set; }

        public string InvoiceNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public bool IsPaid { get; set; } = false;

        public string Currency { get; set; } = "TRY";
        public string? PdfUrl { get; set; }

        public int PaymentId { get; set; }

    }

}
