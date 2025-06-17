using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.CustomerDtos;

namespace Tam.Application.Validators.Customer
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim boş olamaz")
              .MinimumLength(5).MaximumLength(50).WithMessage("İsim 5 ila 50 karakter arasında olmalıdır");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş olamaz.")
               .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz. (Örn: +905555555555)");
            RuleFor(x => x.Address).NotEmpty().WithMessage("Adres bilgisi boş olamaz")
                .MaximumLength(500).WithMessage("Adres bilgisi en fazla 500 karakter olabilir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş olamaz.")
               .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
               .MaximumLength(100).WithMessage("Email en fazla 100 karakter olmalıdır.");
        }
    }
}
