using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.VehicleDtos;

namespace Tam.Application.Validators.Vehicle
{
    public class CreateVehicleDtoValidator : AbstractValidator<CreateVehicleDto>
    {
        public CreateVehicleDtoValidator()
        {
            RuleFor(x => x.Type).NotEmpty().WithMessage("Tip boş olamaz.").MaximumLength(30).WithMessage("Araç Tipi en fazla 30 karakter olabilir.");
            RuleFor(x => x.PlateNumber).NotEmpty().WithMessage("Araç plakası boş olamaz").MaximumLength(12).WithMessage("Araç plakası en fazla 12 karakter olabilir");
            RuleFor(x => x.Brand).NotEmpty().WithMessage("Araç markası boş olamaz").MaximumLength(50).WithMessage("Araç markası en fazla 50 karakter olabilir.");
            RuleFor(x => x.Model).NotEmpty().WithMessage("Araç modeli boş olamaz").MaximumLength(4).WithMessage("Araç modeli en fazla 4 karakter olabilir.");
            RuleFor(x => x.Capacity).GreaterThan(0).WithMessage("Araç kapasitesi 0 dan büyük olmalıdır.");
            RuleFor(x => x.Color).NotEmpty().WithMessage("Araç rengi boş olamaz.").MaximumLength(20).WithMessage("Araç rengi en fazla 20 karakter olabilir");
            RuleFor(x => x.SupplierId).NotNull().WithMessage("Tedarikçi boş olamaz.");
        }
    }
}
