using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Facility;

namespace Tam.Application.Validators.Facility
{
    public class UpdateFacilityDtoValidator : AbstractValidator<UpdateFacilityDto>
    {
        public UpdateFacilityDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İmkan adı boş olamaz.")
                .MaximumLength(50).WithMessage("İmkan adı en fazla 50 karakter olabilir.");
        }
    }
}
