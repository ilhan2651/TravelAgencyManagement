namespace Tam.Application.Dtos.HotelRoomOptionDtos
{
    public class ListHotelRoomOptionDto
    {
        public int Id { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
    }
}
