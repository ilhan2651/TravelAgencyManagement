using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class TourReservation : Reservation
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public Invoice? Invoice { get; set; }


    }
}
