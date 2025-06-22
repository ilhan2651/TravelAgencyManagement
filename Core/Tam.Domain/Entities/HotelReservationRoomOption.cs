using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class HotelReservationRoomOption
    {
        public int HotelReservationId { get; set; }
        public HotelReservation HotelReservation { get; set; }

        public int HotelRoomOptionId { get; set; }
        public HotelRoomOption HotelRoomOption { get; set; }

        public int Quantity { get; set; }
    }

}
