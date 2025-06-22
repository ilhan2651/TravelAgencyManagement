using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities.JoinTables
{
    public class DriverLocation
    {
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public string? Note { get; set; }
    }
}
