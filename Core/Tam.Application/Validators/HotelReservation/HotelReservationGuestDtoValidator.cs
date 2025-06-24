using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.HotelReservationDtos;

namespace Tam.Application.Validators.HotelReservation
{
    public class HotelReservationGuestDtoValidator : AbstractValidator<HotelReservationGuestDto>
    {
        public HotelReservationGuestDtoValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Misafir adı boş olamaz.")
                .MaximumLength(100).WithMessage("Misafir adı en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Age)
                .InclusiveBetween(0, 120).WithMessage("Yaş 0 ile 120 arasında olmalıdır.");
        }
    }
}
