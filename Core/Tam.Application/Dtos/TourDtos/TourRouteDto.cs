using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TourDtos
{
    public class TourRouteDto
    {
        public string Name { get; set; } = string.Empty;
        public string? StartLocationName { get; set; }
        public string? EndLocationName { get; set; }
        public ICollection<TourRouteStopDto> Stops { get; set; } = [];
    }
}
