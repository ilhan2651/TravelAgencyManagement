using Tam.Domain.Entities.JoinTables;

namespace Tam.Application.Factories
{
    public static class TourHotelFactory
    {
        public static TourHotel Create(int tourId, int hotelId)
        {
            return new TourHotel
            {
                TourId = tourId,
                HotelId = hotelId
            };
        }
    }
}