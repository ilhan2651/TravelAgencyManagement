using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Supplier;

namespace Tam.Application.Validators.Supplier
{
    public class UpdateSupplierDtoValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tedarikçi adı boş olamaz.")
                .MaximumLength(100);

            RuleFor(x => x.ContactPerson)
                .NotEmpty().WithMessage("İlgili kişi boş olamaz.")
                .MaximumLength(100);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^\d{10,15}$");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress();

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MaximumLength(250);

            RuleFor(x => x.SupplierType)
                .NotEmpty().WithMessage("Tedarikçi tipi boş olamaz.");
        }
    }
}
