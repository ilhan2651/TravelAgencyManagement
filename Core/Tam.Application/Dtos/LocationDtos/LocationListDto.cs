using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.LocationDtos
{
    public class LocationListDto
    {
        public int Id { get; set; }
        public string? Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? District { get; set; } = string.Empty;
        public ICollection<Hotel>? Hotels { get; set; }
        public ICollection<GuideLocation>? GuideLocations { get; set; }
        public ICollection<DriverLocation>? DriverLocations { get; set; }
    }
}
