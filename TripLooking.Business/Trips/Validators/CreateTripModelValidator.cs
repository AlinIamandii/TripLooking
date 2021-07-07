using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using TripLooking.Business.Trips.Models;

namespace TripLooking.Business.Trips.Validators
{
    public sealed class CreateTripModelValidator : AbstractValidator<CreateTripModel>
    {
        public CreateTripModelValidator()
        {
            RuleFor(x => x.Description)
                .MaximumLength(100)
                .WithMessage("Description is too long");

            RuleFor(x => x.Title)
                .MaximumLength(50)
                .MinimumLength(5);
        }
    }
}
