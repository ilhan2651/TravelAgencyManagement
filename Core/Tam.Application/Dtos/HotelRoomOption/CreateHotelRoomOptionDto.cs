namespace Tam.Application.Dtos.HotelRoomOptionDtos
{
    public class CreateHotelRoomOptionDto
    {
        public int HotelId { get; set; }
        public int RoomTypeId { get; set; }
        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
    }
}
