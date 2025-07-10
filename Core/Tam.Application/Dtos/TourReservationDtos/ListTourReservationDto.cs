using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TourReservationDtos
{

    public class ListTourReservationDto
    {
        public int Id { get; set; }
        public int NumberOfPeople { get; set; }
        public string Status { get; set; } = string.Empty;
        public int TotalPrice { get; set; }
        public string TourName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
    }

}
