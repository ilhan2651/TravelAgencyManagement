using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class TourVehicle
    {
        public int ToureId { get; set; }
        public Tour Tour { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public string? Note { get; set; }
    }
}
