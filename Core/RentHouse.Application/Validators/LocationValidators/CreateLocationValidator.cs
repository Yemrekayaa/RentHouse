using FluentValidation;
using RentHouse.Application.Features.CQRS.Locations.Commands.Create;

namespace RentHouse.Application.Validators.LocationValidators
{
    public class CreateLocationValidator : AbstractValidator<CreateLocationCommand>
    {
        public CreateLocationValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("�sim alan� bo� b�rak�lamaz.")
            .MaximumLength(25).WithMessage("�sim alan� en fazla 25 karakter olabilir.");
        }
    }
}
