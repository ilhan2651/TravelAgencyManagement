using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.RoomType;

namespace Tam.Application.Validators.RoomType
{
    public class CreateRoomTypeDtoValidator : AbstractValidator<CreateRoomTypeDto>
    {
        public CreateRoomTypeDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Oda tipi adı boş olamaz.").MaximumLength(50).WithMessage("Oda tipi ismi en fazla 50 karakter olabilir.");
            RuleFor(x => x.Description)
                .MaximumLength(500)
                .WithMessage("Oda Açıklaması  en fazla 500 karakter olabilir.");
        }
    }

}
