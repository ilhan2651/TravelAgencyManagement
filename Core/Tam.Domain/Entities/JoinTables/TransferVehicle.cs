using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities.JoinTables
{
    public class TransferVehicle
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
