using System.Linq;
using FluentAssertions;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Validators;
using Xunit;

namespace TripLooking.Business.Tests
{
    public class CreateTripModelValidatorTests : TestsBase<CreateTripModelValidator>
    {
        protected override void CreateMocks()
        {
        }

        protected override CreateTripModelValidator CreateSUT() => new();

        [Fact]
        public void When_DescriptionLengthIsGreaterThan100_Expect_ReturnValidationError()
        {
            var model = new UpsertTripModel
            {
                Description = string.Empty.PadLeft(101, 'x'),
                Title = "title"
            };

            var result = SUT.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.First().ErrorCode.Should().BeEquivalentTo("MaximumLengthValidator");
            result.Errors.First().PropertyName.Should().BeEquivalentTo(nameof(model.Description));
            result.Errors.First().ErrorMessage.Should().BeEquivalentTo("Description is too long.");
        }

        [Fact]
        public void When_TitleLengthIsLessThan5_Expect_ReturnValidationError()
        {
            var model = new UpsertTripModel
            {
                Description = "dummy",
                Title = "ti"
            };

            var result = SUT.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.First().ErrorCode.Should().BeEquivalentTo("MinimumLengthValidator");
            result.Errors.First().PropertyName.Should().BeEquivalentTo(nameof(model.Title));
        }

        [Fact]
        public void When_TitleLengthIsGreaterThan50_Expect_ReturnValidationError()
        {
            var model = new UpsertTripModel
            {
                Description = "dummy",
                Title = "ti".PadLeft(51, 'x')
            };

            var result = SUT.Validate(model);

            result.IsValid.Should().BeFalse();
            result.Errors.Count.Should().Be(1);
            result.Errors.First().ErrorCode.Should().BeEquivalentTo("MaximumLengthValidator");
            result.Errors.First().PropertyName.Should().BeEquivalentTo(nameof(model.Title));
        }

        [Fact]
        public void When_ModelIsValid_Expect_ReturnNoValidationError()
        {
            var model = new UpsertTripModel
            {
                Description = "dummy",
                Title = "title"
            };

            var result = SUT.Validate(model);

            result.IsValid.Should().BeTrue();
            result.Errors.Count.Should().Be(0);
        }
    }
}
