using Tam.Application.Dtos.HotelReservationDtos;
using Tam.Domain.Entities;
using Tam.Domain.Enums;
using Tam.Domain.Enums.Tam.Domain.Enums;

namespace Tam.Application.Factories
{
    public static class HotelReservationFactory
    {
        public static HotelReservation Create(CreateHotelReservationDto dto, Discount? discount)
        {
            var reservation = new HotelReservation
            {
                HotelId = dto.HotelId,
                CustomerId = dto.CustomerId,
                CheckIn = dto.CheckIn,
                CheckOut = dto.CheckOut,
                DiscountId = dto.DiscountId,
                PaymentId = dto.PaymentId,
                NumberOfPeople = dto.NumberOfPeople,
                Status = dto.Status,
                Note = dto.Note,
                ReservationDate = DateTime.UtcNow,
                ReservedRooms = dto.ReservedRooms.Select(x => new HotelReservationRoomOption
                {
                    HotelRoomOptionId = x.HotelRoomOptionId,
                    Quantity = x.Quantity
                }).ToList(),
                Guests = dto.Guests.Select(x => new HotelReservationGuest
                {
                    FullName = x.FullName,
                    Age = x.Age,
                    IdentityNumber = x.IdentityNumber,
                    Note = x.Note
                }).ToList()
            };

            reservation.TotalPrice = CalculateTotalPrice(dto.ReservedRooms, discount);

            return reservation;
        }

        public static void Update(HotelReservation entity, UpdateHotelReservationDto dto, Discount? discount)
        {
            entity.HotelId = dto.HotelId;
            entity.CustomerId = dto.CustomerId;
            entity.CheckIn = dto.CheckIn;
            entity.CheckOut = dto.CheckOut;
            entity.DiscountId = dto.DiscountId;
            entity.PaymentId = dto.PaymentId;
            entity.NumberOfPeople = dto.NumberOfPeople;
            entity.Status = dto.Status;
            entity.Note = dto.Note;
            entity.UpdatedAt = DateTime.UtcNow;

            entity.ReservedRooms.Clear();
            entity.Guests.Clear();

            entity.ReservedRooms = dto.ReservedRooms.Select(x => new HotelReservationRoomOption
            {
                HotelRoomOptionId = x.HotelRoomOptionId,
                Quantity = x.Quantity
            }).ToList();

            entity.Guests = dto.Guests.Select(x => new HotelReservationGuest
            {
                FullName = x.FullName,
                Age = x.Age,
                IdentityNumber = x.IdentityNumber,
                Note = x.Note
            }).ToList();

            entity.TotalPrice = CalculateTotalPrice(dto.ReservedRooms, discount);
        }

        private static int CalculateTotalPrice(List<ReservedRoomDto> reservedRooms, Discount? discount)
        {
            decimal total = 0;

            foreach (var room in reservedRooms)
            {
                total += room.PricePerNight * room.Quantity;
            }

            if (discount is not null)
            {
                if (discount.Type == DiscountType.Percentage)
                    total -= total * (discount.Value / 100m);
                else if (discount.Type == DiscountType.Fixed)
                    total -= discount.Value;
            }

            return (int)Math.Round(total);
        }
    }
}
