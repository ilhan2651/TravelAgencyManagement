using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.PaymentMethodDtos;

namespace Tam.Application.Validators
{
    public class CreatePaymentMethodDtoValidator :  AbstractValidator<CreatePaymentMethodDto>  
    {
        public CreatePaymentMethodDtoValidator()
        {
            RuleFor(x => x.Method)
                .NotEmpty().WithMessage("Ödeme yöntemi boş olamaz.")
                .MaximumLength(100).WithMessage("Ödeme yöntemi en fazla 100 karakter olabilir.");
        }
    }
}
