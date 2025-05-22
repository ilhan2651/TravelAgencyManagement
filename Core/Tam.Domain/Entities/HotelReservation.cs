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
        public Invoice? Invoice { get; set; }
        public HotelPurchase? HotelPurchase { get; set; }


    }
}
