using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.HotelReservationDtos;

namespace Tam.Application.Validators.HotelReservation
{
    public class CreateHotelReservationDtoValidator : AbstractValidator<CreateHotelReservationDto>
    {
        public CreateHotelReservationDtoValidator()
        {
            RuleFor(x => x.HotelId).GreaterThan(0).WithMessage("Geçerli bir otel seçilmelidir.");
            RuleFor(x => x.CustomerId).GreaterThan(0).WithMessage("Geçerli bir müşteri seçilmelidir.");
            RuleFor(x => x.CheckIn).LessThan(x => x.CheckOut)
                .WithMessage("Check-in tarihi, check-out tarihinden önce olmalıdır.");
            RuleFor(x => x.NumberOfPeople).GreaterThan(0).WithMessage("Kişi sayısı 0'dan büyük olmalıdır.");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Rezervasyon durumu boş olamaz.");
            RuleForEach(x => x.Guests).SetValidator(new HotelReservationGuestDtoValidator());
            RuleForEach(x => x.ReservedRooms).SetValidator(new ReservedRoomDtoValidator());
        }
    }
}
