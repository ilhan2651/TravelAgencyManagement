using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelReservationDtos
{

    public class ReservedRoomDetailDto
    {
        public string RoomTypeName { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int Quantity { get; set; }
    }


}
