using FluentValidation;
using TripLooking.Business.Trips.Models;

namespace TripLooking.Business.Trips.Validators
{
    public sealed class CreateTripModelValidator : AbstractValidator<CreateTripModel>
    {
        public CreateTripModelValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(1000);
            RuleFor(x => x.Title)
                .MaximumLength(50)
                .MinimumLength(3)
                .NotEmpty()
                .NotNull();
        }
    }
}
