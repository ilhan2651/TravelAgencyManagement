using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.GuideLocation
{
    public class GuideLocationDto
    {
        public int Id { get; set; }
        public string? Country { get; set; }
        public string City { get; set; } = string.Empty;
        public string? District { get; set; }
        public bool IsPrimary { get; set; }
    }
}
