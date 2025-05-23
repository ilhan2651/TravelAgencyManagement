using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaidAt { get; set; }
        public bool IsRefunded { get; set; } = false;
        public string TransactionCode { get; set; } = string.Empty;
        public int? PaymentMethodId { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        public ICollection<HotelReservation>? HotelReservations { get; set; }
        public ICollection<TourReservation>? TourReservations { get; set; }
        public ICollection<TransferReservation>? TransferReservations{ get; set; }

    }
}
