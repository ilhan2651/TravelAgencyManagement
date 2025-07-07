using FluentValidation;
using Tam.Application.Dtos.TourDtos;

namespace Tam.Application.Validators.Tour
{
    public class CreateTourDtoValidator : AbstractValidator<CreateTourDto>
    {
        public CreateTourDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tur adı boş olamaz.")
                .MaximumLength(100).WithMessage("Tur adı en fazla 100 karakter olabilir.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Fiyat negatif olamaz.");
            RuleFor(x => x.Capacity)
                .GreaterThan(0).WithMessage("Kapasite 0'dan büyük olmalıdır.");
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).WithMessage("Başlangıç tarihi bitiş tarihinden önce olmalıdır.");
            RuleFor(x => x.GuideId)
                .GreaterThan(0).WithMessage("Geçerli bir rehber seçilmelidir.");
            RuleFor(x => x.AppranteeId)
                .GreaterThan(0).WithMessage("Geçerli bir apprantee seçilmelidir.");
        }
    }
}