using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Location : BaseEntity
    {
        public string? Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? District { get; set; } = string.Empty;
        public ICollection<Hotel>? Hotels { get; set; }
        public ICollection<GuideLocation> GuideLocations { get; set; }
        public ICollection<DriverLocation> DriverLocations { get; set; }
        public ICollection<Tour>? StartTours { get; set; }
        public ICollection<Tour>? EndTours { get; set; }
        public ICollection<Transfer>? StartTransfers { get; set; }
        public ICollection<Transfer>? EndTransfers { get; set; }
        public ICollection<Route>? StartRoutes { get; set; }
        public ICollection<Route>? EndRoutes { get; set; }



    }
}
