using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        public string PlateNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Color { get; set; } = string.Empty;
        public int? SupplierId  { get; set; }
        public Supplier? Supplier { get; set; }
        public ICollection<TourVehicle>? TourVehicles { get; set; }
        public ICollection<Transfer>? Transfers { get; set; }


    }
}
