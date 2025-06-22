using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities.JoinTables
{
    public class TourDriver
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
    }
}
