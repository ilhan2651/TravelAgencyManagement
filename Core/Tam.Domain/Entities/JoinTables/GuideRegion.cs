using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities.JoinTables
{
    public class GuideRegion
    {
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
        public int RegionId { get; set; }
        public Region Region { get; set; }

    }
}
