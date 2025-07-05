using FluentValidation;
using Tam.Application.Dtos.TransferReservationDtos;

namespace Tam.Application.Validators.TransferReservation
{
    public class UpdateTransferReservationDtoValidator : AbstractValidator<UpdateTransferReservationDto>
    {
        public UpdateTransferReservationDtoValidator()
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

            RuleFor(x => x.TransferId)
                .GreaterThan(0)
                .WithMessage("Transfer seçilmelidir.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0)
                .WithMessage("Müşteri seçilmelidir.");

            RuleFor(x => x.PickUpPoint)
                .NotEmpty()
                .WithMessage("Alış noktası boş olamaz.");

            RuleFor(x => x.DropOffPoint)
                .NotEmpty()
                .WithMessage("Bırakılacak nokta boş olamaz.");
        }
    }
}
