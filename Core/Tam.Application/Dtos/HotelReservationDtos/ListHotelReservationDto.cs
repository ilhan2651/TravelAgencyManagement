using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelReservationDtos
{
    public class ListHotelReservationDto
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
