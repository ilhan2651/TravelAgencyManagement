using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.Email
{
    public class HotelReservationEmailMessage
    {
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public DateTime CheckIn { get; set; }
        public int NumberOfPeople { get; set; }
    }

}
