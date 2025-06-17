using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.DriverDto;
using Tam.Application.Dtos.VehicleDto;

namespace Tam.Application.Dtos.Supplier
{
    public class SupplierListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? TaxNumber { get; set; }
        public string SupplierType { get; set; } = string.Empty;
        public ICollection<SupplierDriverDto>? Drivers { get; set; } = new List<SupplierDriverDto>();
        public ICollection<SupplierVehicleDto>? Vehicles { get; set; } = new List<SupplierVehicleDto>();
    }
}
