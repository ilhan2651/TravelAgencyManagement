using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.DriverDtos
{

    public class DriverDetailDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? SupplierId { get; set; }
        public string? SupplierName { get; set; }
        public string LicenseNumber { get; set; } = string.Empty;
        public DateTime? LicenseExpiryDate { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public List<DriverTourDto>? Tours { get; set; }
        public List<DriverTransferDto>? Transfers { get; set; }
        public List<DriverLocation>? DriverLocations { get; set; }

    }


}
