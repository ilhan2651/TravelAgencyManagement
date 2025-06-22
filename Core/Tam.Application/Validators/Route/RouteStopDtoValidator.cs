using FluentValidation;
using Tam.Application.Dtos.RouteDtos;

namespace Tam.Application.Validators.Route
{
    public class RouteStopDtoValidator : AbstractValidator<RouteStopDto>
    {
        public RouteStopDtoValidator()
        {
            RuleFor(x => x.LocationId)
                .GreaterThan(0).WithMessage("Lokasyon seçilmelidir.");

            RuleFor(x => x.Note)
                .MaximumLength(500)
                .WithMessage("Not en fazla 500 karakter olabilir.");

            RuleFor(x => x.Order)
                .GreaterThanOrEqualTo(0);
        }
    }
}
