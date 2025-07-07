using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class TourRegionFactory
    {
        public static TourRegion Create(int tourId, int regionId)
        {
            return new TourRegion
            {
                TourId = tourId,
                RegionId = regionId
            };
        }
    }
}