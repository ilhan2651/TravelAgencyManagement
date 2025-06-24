using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelReservationDtos
{

    public class ReservedRoomDto
    {
        public int HotelRoomOptionId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerNight { get; set; }
    }


}
