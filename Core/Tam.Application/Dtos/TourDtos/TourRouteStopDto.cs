using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TourDtos
{
    public class TourRouteStopDto
    {
        public int Order { get; set; }
        public string? Note { get; set; }
        public int? StopDurationMinutes { get; set; }
        public string LocationName { get; set; } = string.Empty;
    }
}
