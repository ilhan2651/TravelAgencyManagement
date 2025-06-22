
using Tam.Domain.Common;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Domain.Entities
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public decimal PricePerNight { get; set; }
        public int? LocationId { get; set; }
        public Location? Location { get; set; }
        public bool IsActive { get; set; }

        public ICollection<HotelRoomOption> RoomOptions { get; set; }
        public ICollection<HotelFacility> HotelFacilities { get; set; } = new List<HotelFacility>();
        public ICollection<HotelReservation>? HotelReservations { get; set; }
        public ICollection<HotelPurchase>? HotelPurchases { get; set; }
        public ICollection<DiscountHotel>? DiscountHotels { get; set; }
        public ICollection<TourHotel>? TourHotels { get; set; }


    }
}
