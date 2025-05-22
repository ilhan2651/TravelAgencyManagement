using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class DriverTransfer
    {
        public int DriverId { get; set; }
        public Driver Driver { get; set; }
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
    }
}
