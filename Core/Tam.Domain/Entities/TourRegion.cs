using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class TourRegion
    {
        public int TourId { get; set; }
        public Tour Tour { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }
    }
}
