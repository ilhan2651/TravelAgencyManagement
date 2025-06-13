using FluentValidation;
using Tam.Application.Dtos.UserDtos;

namespace Tam.Application.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .MinimumLength(3).WithMessage("İsim en az 4 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email alanı boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.")
                .MaximumLength(100).WithMessage("Email en fazla 100 karakter olmalıdır.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre alanı boş olamaz.")
                .MinimumLength(8).WithMessage("Şifre en az 6 karakter olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"[a-z]").WithMessage("Şifre en az bir küçük harf içermelidir.")
                .Matches(@"[0-9]").WithMessage("Şifre en az bir rakam içermelidir.");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre onayı boş olamaz.")
                .Equal(x => x.Password).WithMessage("Şifre onayı şifre ile eşleşmelidir.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş olamaz.")
                .Matches(@"^\+?[0-9]{10,15}$").WithMessage("Geçerli bir telefon numarası giriniz. (Örn: +905555555555)");
                
                

        }
    }
}
