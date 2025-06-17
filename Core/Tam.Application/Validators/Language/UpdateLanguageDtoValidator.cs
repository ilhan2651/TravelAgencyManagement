using FluentValidation;
using Tam.Application.Dtos.Language;

namespace Tam.Application.Validators.Language
{
    public class UpdateLanguageDtoValidator : AbstractValidator<UpdateLanguageDto>
    {
        public UpdateLanguageDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Dil adı boş olamaz.")
                .MaximumLength(30).WithMessage("Dil adı en fazla 30 karakter olabilir.");
        }
    }
}