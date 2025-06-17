using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Region;

namespace Tam.Application.Validators.Region
{
    public class UpdateRegionDtoValidator  :AbstractValidator<UpdateRegionDto>
    {
        public UpdateRegionDtoValidator()
        {
            RuleFor(r => r.Name).NotEmpty().WithMessage("İsim boş olamaz").MaximumLength(50).WithMessage("Bölge ismi 50 karakteri geçmemelidir");

        }
    }
}
