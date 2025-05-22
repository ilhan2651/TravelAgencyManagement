using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Region : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<GuideRegion>? GuideRegions { get; set; }
        public ICollection<TourRegion>? TourRegions { get; set; }

    }
}
