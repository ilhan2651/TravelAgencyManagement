using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Driver : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime? LicenseExpiryDate { get; set; }
  
        public ICollection<DriverLocation> DriverLocations { get; set; }
        public ICollection<DriverTransfer>? DriverTransfers { get; set; }



    }
}
