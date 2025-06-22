using FluentValidation;
using Tam.Application.Dtos.RouteDtos;

namespace Tam.Application.Validators.Route
{
    public class CreateRouteDtoValidator : AbstractValidator<CreateRouteDto>
    {
        public CreateRouteDtoValidator()
        {
            RuleFor(r => r.Name)
                .NotEmpty().WithMessage("Rota adı boş olamaz.")
                .MaximumLength(150).WithMessage("Rota adı en fazla 150 karakter olabilir.");

            RuleForEach(r => r.RouteStops)
                .SetValidator(new RouteStopDtoValidator());
        }
    }
}
