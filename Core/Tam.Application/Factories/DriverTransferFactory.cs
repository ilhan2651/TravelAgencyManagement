using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class DriverTransferFactory
    {
        public static DriverTransfer Create(int driverId, int transferId)
        {
            return new DriverTransfer
            {
                DriverId = driverId,
                TransferId = transferId
            };
        }
    }
}
