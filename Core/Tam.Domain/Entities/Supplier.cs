using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Supplier : BaseEntity
    {

        public string Name { get; set; } = string.Empty;
        public string ContactPerson { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? TaxNumber { get; set; }
        public string SupplierType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public ICollection<Driver>? Drivers { get; set; }
        public ICollection<Vehicle>? Vehicles { get; set; }

    }
}
