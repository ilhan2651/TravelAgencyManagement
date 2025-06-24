using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelReservationDtos
{
    public class HotelReservationGuestDto
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Note { get; set; }
    }
}
