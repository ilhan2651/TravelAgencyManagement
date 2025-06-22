using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.PaymentDtos;

namespace Tam.Application.Validators.Payment
{
    public class CreatePaymentDtoValidator : AbstractValidator<CreatePaymentDto>
    {
        public CreatePaymentDtoValidator()
        {
            RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Tutar sıfırdan büyük olmalıdır.");

            RuleFor(x => x.PaidAt)
                .NotEmpty().WithMessage("Ödeme tarihi boş olamaz.");

            RuleFor(x => x.PaymentMethodId)
                .NotNull().WithMessage("Ödeme yöntemi belirtilmelidir.");

            RuleFor(x => x.TransactionCode)
                .NotEmpty().WithMessage("İşlem kodu boş olamaz.")
                .When(x => x.IsPaid)
                .WithMessage("Ödeme yapıldıysa işlem kodu girilmelidir.");
        }
    }
}
