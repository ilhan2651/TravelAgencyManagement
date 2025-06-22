using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.Transfer
{
    public class TransferListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public int PassengerCount { get; set; }
        public bool IsCompleted { get; set; }
        public string? StartLocationName { get; set; }
        public string? EndLocationName { get; set; }
    }
        
}
