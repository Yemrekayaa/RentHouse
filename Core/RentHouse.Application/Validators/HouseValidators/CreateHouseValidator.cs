using FluentValidation;
using RentHouse.Application.Features.CQRS.Houses.Commands.Create;

namespace RentHouse.Application.Validators.HouseValidators
{
    public class CreateHouseValidator : AbstractValidator<CreateHouseWithFeaturesCommand>
    {
        public CreateHouseValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("�sim alan� bo� b�rak�lamaz.")
            .MaximumLength(100).WithMessage("�sim alan� en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("A��klama alan� bo� b�rak�lamaz.")
                .MaximumLength(500).WithMessage("A��klama en fazla 500 karakter olabilir.");

            RuleFor(x => x.CoverImageUrl)
                .NotEmpty().WithMessage("Kapak g�rseli URL'si bo� b�rak�lamaz.");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("Alan s�f�rdan b�y�k olmal�d�r.");

            RuleFor(x => x.NumberOfRooms)
                .GreaterThan((byte)0).WithMessage("Oda say�s� s�f�rdan b�y�k olmal�d�r.");

            RuleFor(x => x.NumberOfBeds)
                .GreaterThan((byte)0).WithMessage("Yatak say�s� s�f�rdan b�y�k olmal�d�r.");



            RuleFor(x => x.WeekdayPrice)
                .GreaterThan(0).WithMessage("Hafta i�i fiyat� s�f�rdan b�y�k olmal�d�r.");

            RuleFor(x => x.WeekendPrice)
                .GreaterThan(0).WithMessage("Hafta sonu fiyat� s�f�rdan b�y�k olmal�d�r.");

            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Enlem -90 ile 90 aras�nda olmal�d�r.");

            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Boylam -180 ile 180 aras�nda olmal�d�r.");

        }
    }
}
