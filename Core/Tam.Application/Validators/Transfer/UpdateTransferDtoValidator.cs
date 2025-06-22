using FluentValidation;
using Tam.Application.Dtos.Transfer;

namespace Tam.Application.Validators.Transfer
{
    public class UpdateTransferDtoValidator : AbstractValidator<UpdateTransferDto>
    {
        public UpdateTransferDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Transfer adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.PassengerCount)
                .GreaterThanOrEqualTo(0).When(x => x.PassengerCount != null)
                .WithMessage("Yolcu sayısı negatif olamaz.");

            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime).When(x => x.StartTime != null && x.EndTime != null)
                .WithMessage("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");
        }
    }
}
