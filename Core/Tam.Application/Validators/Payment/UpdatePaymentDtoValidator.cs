using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.PaymentDtos;

namespace Tam.Application.Validators.Payment
{
    public class UpdatePaymentDtoValidator : AbstractValidator<UpdatePaymentDto>
    {
        public UpdatePaymentDtoValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThan(0).When(x => x.Amount.HasValue)
                .WithMessage("Tutar sıfırdan büyük olmalıdır.");

            RuleFor(x => x.PaidAt)
                .NotEmpty().When(x => x.PaidAt.HasValue)
                .WithMessage("Ödeme tarihi boş olamaz.");

            RuleFor(x => x.TransactionCode)
                .NotEmpty().WithMessage("İşlem kodu boş olamaz.")
                .When(x => x.IsPaid.HasValue && x.IsPaid.Value)
                .WithMessage("Ödeme yapıldıysa işlem kodu girilmelidir.");
        }
    }
}
