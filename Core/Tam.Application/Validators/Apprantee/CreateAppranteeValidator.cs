using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Aprantee;

namespace Tam.Application.Validators.Apprantee
{
    public class CreateAppranteeValidator : AbstractValidator<CreateAppranteeDto>
    {
        public CreateAppranteeValidator()
        {
            
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("İsim boş bırakılamaz")
                .MinimumLength(5).MaximumLength(50).WithMessage("İsim 5-50 karakter arasında olmalıdır.");
            RuleFor(x => x.PhoneNumber).NotNull()
                .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz")
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Telefon numarası geçerli bir formatta olmalıdır.");
            RuleFor(x => x.Email).NotNull()
                .NotEmpty().WithMessage("E-posta boş bırakılamaz")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
      
        }
    }
}
