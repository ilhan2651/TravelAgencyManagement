using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Invoice : BaseEntity
    {

        public string InvoiceNumber { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime InvoiceDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }
        public decimal TaxAmount { get; set; }
        public decimal SubTotal { get; set; }
        public bool IsPaid { get; set; } = false;

        public int? CurrencyId { get; set; }
        public Currency? Currency { get; set; }
        public string? PdfUrl { get; set; }

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }

        public int? TourReservationId { get; set; }
        public TourReservation? TourReservation { get; set; }

        public int? HotelReservationId { get; set; }
        public HotelReservation? HotelReservation { get; set; }

        public int? TransferReservationId { get; set; }
        public TransferReservation? TransferReservation { get; set; }



    }

}
