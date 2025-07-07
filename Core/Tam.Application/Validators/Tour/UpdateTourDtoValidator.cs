using FluentValidation;
using Tam.Application.Dtos.TourDtos;

namespace Tam.Application.Validators.Tour
{
    public class UpdateTourDtoValidator : AbstractValidator<UpdateTourDto>
    {
        public UpdateTourDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).When(x => !string.IsNullOrWhiteSpace(x.Name));
            RuleFor(x => x.Description)
                .MaximumLength(500).When(x => !string.IsNullOrWhiteSpace(x.Description));
            RuleFor(x => x.Price)
                .GreaterThanOrEqualTo(0).When(x => x.Price != default)
                .WithMessage("Fiyat negatif olamaz.");
            RuleFor(x => x.Capacity)
                .GreaterThan(0).When(x => x.Capacity != default)
                .WithMessage("Kapasite 0'dan büyük olmalıdır.");
            RuleFor(x => x.StartDate)
                .LessThan(x => x.EndDate).When(x => x.StartDate != default && x.EndDate != default)
                .WithMessage("Başlangıç tarihi bitiş tarihinden önce olmalıdır.");
        }
    }
}