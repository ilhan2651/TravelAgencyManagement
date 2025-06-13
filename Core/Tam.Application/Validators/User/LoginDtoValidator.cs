using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.UserDtos;

namespace Tam.Application.Validators.User
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş geçilemez")
                .EmailAddress().WithMessage("Geçerli bir email giriniz.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre alanı boş geçilemez");
                


        }
    }
}
