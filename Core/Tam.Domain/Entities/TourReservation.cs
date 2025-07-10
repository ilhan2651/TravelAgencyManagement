using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class TourReservation : Reservation
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public int? DiscountId { get; set; } 
        public Discount? Discount { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<TourReservationGuest> Guests { get; set; } = new List<TourReservationGuest>();

    }
}
