using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.Transfer
{
    public class CreateTransferDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AppranteeId { get; set; }
        public int RouteId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int PassengerCount { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? StartLocationId { get; set; }
        public int? EndLocationId { get; set; }
        
    }
}
