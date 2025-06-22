using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Domain.Entities
{
    public class Route : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public int? StartLocationId { get; set; }
        [ForeignKey(nameof(StartLocationId))]

        public Location? StartLocation { get; set; }
        public int? EndLocationId { get; set; }
        [ForeignKey(nameof(EndLocationId))]

        public Location? EndLocation { get; set; }

        public ICollection<RouteStop>? RouteStops { get; set; }
        public ICollection<Tour>? Tours { get; set; }
    }
}
