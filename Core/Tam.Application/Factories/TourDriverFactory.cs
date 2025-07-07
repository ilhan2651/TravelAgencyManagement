using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class TourDriverFactory
    {
        public static TourDriver Create(int tourId, int driverId)
        {
            return new TourDriver
            {
                TourId = tourId,
                DriverId = driverId
            };
        }
    }
}