using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.HotelReservationDtos;

namespace Tam.Application.Validators.HotelReservation
{
    public class ReservedRoomDtoValidator : AbstractValidator<ReservedRoomDto>
    {
        public ReservedRoomDtoValidator()
        {
            RuleFor(x => x.HotelRoomOptionId).GreaterThan(0).WithMessage("Geçerli bir oda seçilmelidir.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Oda adedi 0'dan büyük olmalıdır.");
            RuleFor(x => x.PricePerNight).GreaterThan(0).WithMessage("Gecelik fiyat 0'dan büyük olmalıdır.");
        }
    }
}
