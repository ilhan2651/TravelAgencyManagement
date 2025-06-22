using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class TransferVehicleFactory
    {
        public static TransferVehicle Create(int transferId, int vehicleId)
        {
            return new TransferVehicle
            {
                TransferId = transferId,
                VehicleId = vehicleId
            };
        }
    }
}
