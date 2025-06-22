using FluentValidation;
using Tam.Application.Dtos.Transfer;

namespace Tam.Application.Validators.Transfer
{
    public class CreateTransferDtoValidator : AbstractValidator<CreateTransferDto>
    {
        public CreateTransferDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Transfer adı boş olamaz.")
                .MaximumLength(100).WithMessage("Transfer adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.AppranteeId)
                .GreaterThan(0).WithMessage("Geçerli bir rehber (apprantee) seçilmelidir.");

            RuleFor(x => x.RouteId)
                .GreaterThan(0).WithMessage("Geçerli bir rota seçilmelidir.");

            RuleFor(x => x.PassengerCount)
                .GreaterThanOrEqualTo(0).WithMessage("Yolcu sayısı negatif olamaz.");

            RuleFor(x => x.StartTime)
                .LessThan(x => x.EndTime).WithMessage("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");

            RuleFor(x => x.StartLocationId)
                .NotNull().WithMessage("Başlangıç lokasyonu belirtilmelidir.");

            RuleFor(x => x.EndLocationId)
                .NotNull().WithMessage("Bitiş lokasyonu belirtilmelidir.");
        }
    }
}
