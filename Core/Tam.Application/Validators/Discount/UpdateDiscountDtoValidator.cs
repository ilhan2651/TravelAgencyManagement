using FluentValidation;
using Tam.Application.Dtos.DiscountDtos;
using Tam.Domain.Enums;

namespace Tam.Application.Validators.DiscountValidators
{
    public class UpdateDiscountDtoValidator : AbstractValidator<UpdateDiscountDto>
    {
        public UpdateDiscountDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İndirim adı boş olamaz.")
                .MaximumLength(100).WithMessage("İndirim adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Geçersiz indirim türü.");

            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("İndirim değeri sıfırdan büyük olmalıdır.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Başlangıç tarihi boş olamaz.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("Bitiş tarihi, başlangıç tarihinden sonra olmalıdır.");
        }
    }
}
