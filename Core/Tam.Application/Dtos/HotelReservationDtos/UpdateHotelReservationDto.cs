using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelReservationDtos
{
    public class UpdateHotelReservationDto
    {
        public int HotelId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int? DiscountId { get; set; }
        public int? PaymentId { get; set; }

        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;

        public List<ReservedRoomDto> ReservedRooms { get; set; } = [];
        public List<HotelReservationGuestDto> Guests { get; set; } = [];
    }
}
