using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.DriverDto;

namespace Tam.Application.Validators.Driver
{
    public class CreateDriverDtoValidator : AbstractValidator<CreateDriverDto>
    {
        public CreateDriverDtoValidator()
        {
            RuleFor(x => x.FullName)
                 .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                 .MaximumLength(50).WithMessage("Ad soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Telefon numarası boş olamaz.")
                .Matches(@"^(\+90|0)?5\d{9}$").WithMessage("Geçerli bir Türk GSM numarası giriniz.");

            RuleFor(x => x.LicenseNumber)
                .NotEmpty().WithMessage("Ehliyet numarası boş olamaz.")
                .MaximumLength(20).WithMessage("Ehliyet numarası en fazla 20 karakter olabilir.");

            RuleFor(x => x.LicenseExpiryDate)
                .NotNull().WithMessage("Ehliyet geçerlilik tarihi boş olamaz.")
                .GreaterThan(DateTime.Today).WithMessage("Ehliyet geçerlilik tarihi bugünden ileri bir tarih olmalıdır.");

            RuleFor(x => x.SupplierId)
                .NotNull().WithMessage("Tedarikçi seçilmelidir.");
        }
    }
}
