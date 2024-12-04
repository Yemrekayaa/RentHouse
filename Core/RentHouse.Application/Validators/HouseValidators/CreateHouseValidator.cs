using FluentValidation;
using RentHouse.Application.Features.CQRS.Houses.Commands.Create;

namespace RentHouse.Application.Validators.HouseValidators
{
    public class CreateHouseValidator : AbstractValidator<CreateHouseWithFeaturesCommand>
    {
        public CreateHouseValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Ýsim alaný boþ býrakýlamaz.")
            .MaximumLength(100).WithMessage("Ýsim alaný en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açýklama alaný boþ býrakýlamaz.")
                .MaximumLength(500).WithMessage("Açýklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.CoverImageUrl)
                .NotEmpty().WithMessage("Kapak görseli URL'si boþ býrakýlamaz.");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("Alan sýfýrdan büyük olmalýdýr.");

            RuleFor(x => x.NumberOfRooms)
                .GreaterThan((byte)0).WithMessage("Oda sayýsý sýfýrdan büyük olmalýdýr.");

            RuleFor(x => x.NumberOfBeds)
                .GreaterThan((byte)0).WithMessage("Yatak sayýsý sýfýrdan büyük olmalýdýr.");



            RuleFor(x => x.WeekdayPrice)
                .GreaterThan(0).WithMessage("Hafta içi fiyatý sýfýrdan büyük olmalýdýr.");

            RuleFor(x => x.WeekendPrice)
                .GreaterThan(0).WithMessage("Hafta sonu fiyatý sýfýrdan büyük olmalýdýr.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Enlem -90 ile 90 arasýnda olmalýdýr.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Boylam -180 ile 180 arasýnda olmalýdýr.");

        }
    }
}
