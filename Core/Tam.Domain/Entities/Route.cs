using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Route : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int? StartLocationId { get; set; }
        public Location? StartLocation { get; set; }
        public int? EndLocationId { get; set; }
        public Location? EndLocation { get; set; }

        public bool IsActive { get; set; } = true;
        public ICollection<RouteStop>? RouteStops { get; set; }
    }
}
