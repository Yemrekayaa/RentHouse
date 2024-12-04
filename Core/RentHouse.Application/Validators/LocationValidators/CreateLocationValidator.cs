using FluentValidation;
using RentHouse.Application.Features.CQRS.Locations.Commands.Create;

namespace RentHouse.Application.Validators.LocationValidators
{
    public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ýsim alaný boþ býrakýlamaz.")
            .MaximumLength(25).WithMessage("Ýsim alaný en fazla 25 karakter olabilir.");
        }
    }
}
