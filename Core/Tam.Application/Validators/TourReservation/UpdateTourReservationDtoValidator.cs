using FluentValidation;
using Tam.Application.Dtos.TourReservationDtos;

namespace Tam.Application.Validators.TourReservation
{
    public class UpdateTourReservationDtoValidator : AbstractValidator<UpdateTourReservationDto>
    {
        public UpdateTourReservationDtoValidator()
        {
            RuleFor(x => x.NumberOfPeople)
                .GreaterThan(0)
                .WithMessage("Kişi sayısı 0'dan büyük olmalıdır.");

            RuleFor(x => x.TotalPrice)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Toplam fiyat negatif olamaz.");

            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("Rezervasyon durumu boş bırakılamaz.");

            RuleFor(x => x.TourId)
                .GreaterThan(0)
                .WithMessage("Tur seçilmelidir.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("Müşteri seçilmelidir.");
        }
    }
}