using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TourReservationDtos
{
    public class CreateTourReservationGuestsDto
    {
        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Note { get; set; }
    }
}
