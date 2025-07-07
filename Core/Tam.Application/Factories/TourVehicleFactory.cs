using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class TourVehicleFactory
    {
        public static TourVehicle Create(int tourId, int vehicleId)
        {
            return new TourVehicle
            {
                TourId = tourId,
                VehicleId = vehicleId
            };
        }
    }
}