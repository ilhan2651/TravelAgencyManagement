using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.VehicleDto
{
    public class SupplierVehicleDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Color { get; set; } = string.Empty;
    }
}
