using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Supplier;

namespace Tam.Application.Validators.Supplier
{
    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tedarikçi adı boş olamaz.")
                .MaximumLength(100).WithMessage("Tedarikçi adı en fazla 100 karakter olabilir.");

            RuleFor(x => x.ContactPerson)
                .NotEmpty().WithMessage("İlgili kişi adı boş olamaz.")
                .MaximumLength(100);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{10,15}$").WithMessage("Telefon numarası geçerli değil."); 

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(250);

            RuleFor(x => x.SupplierType)
                .NotEmpty().WithMessage("Tedarikçi tipi boş olamaz.");
        }
    }
}
