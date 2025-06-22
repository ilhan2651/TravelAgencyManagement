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
        public static DriverTransfer Create(int transferId,int driverId)
        {
            return new DriverTransfer
            {
                DriverId = driverId,
                TransferId = transferId
            };
        }
    }
}
