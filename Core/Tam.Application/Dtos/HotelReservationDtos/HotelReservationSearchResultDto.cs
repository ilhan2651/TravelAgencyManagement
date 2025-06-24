namespace Tam.Application.Dtos.HotelReservationDtos
{
    public class HotelReservationSearchResultDto
    {
        public int Id { get; set; }
        public string CustomerFullName { get; set; } = string.Empty;
        public string HotelName { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
