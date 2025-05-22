using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class GuideLocation
    {
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }
        public string? Note { get; set; }
        public bool IsPrimary { get; set; }
        
    }
}
