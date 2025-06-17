using FluentValidation;
using Tam.Application.Dtos.LocationDtos;

namespace Tam.Application.Validators.LocationValidators
{
    public class CreateLocationDtoValidator : AbstractValidator<CreateLocationDto>
    {
        public CreateLocationDtoValidator()
        {
            RuleFor(x => x.Country)
                .MaximumLength(30).WithMessage("Ülke adı en fazla 30 karakter olabilir.");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("Şehir alanı boş olamaz.")
                .MaximumLength(30).WithMessage("Şehir adı en fazla 30 karakter olabilir.");

            RuleFor(x => x.District)
                .MaximumLength(30).WithMessage("İlçe adı en fazla 30 karakter olabilir.");
        }
    }
}
