using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class HotelReservation : Reservation
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }
        public HotelPurchase? HotelPurchase { get; set; }
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }

        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<HotelReservationRoomOption> ReservedRooms { get; set; }

    }
}
