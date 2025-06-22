using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Dtos.DriverDto
{
    public class DriverListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; }= string.Empty;
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? LicenseExpiryDate { get; set; }
        public List<DriverLocation> DriverLocations { get; set; }
    }
}
