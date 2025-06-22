using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.RouteDtos;

namespace Tam.Application.Dtos.Transfer
{
    public class TransferRouteDto
    {
        public string Name { get; set; } = string.Empty;
        public string? StartLocationName { get; set; }
        public string? EndLocationName { get; set; }
        public ICollection<TransferRouteStopDto> Stops { get; set; } = [];
    }

}
