using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TripLooking.API.Tests.Extensions;
using TripLooking.Business.Trips.Models;
using Xunit;

namespace TripLooking.API.Tests
{
    public class TripsControllerTests :  IClassFixture<WebApplicationFactory<Startup>>
    {
        public TripsControllerTests(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async void When_GetTrips_Expect_ResponseShouldBeSuccessStatusCode()
        {
            var result = await Client.GetAsync(@"/api/trips");
            
            Assert.True(result.IsSuccessStatusCode);
        }

        [Fact]
        public async void When_CreateTrip_Expect_ResponseShouldBeSuccessStatusCodeAndProvideTheId()
        {
            var model = new UpsertTripModel
            {
                Title = "title",
                Description = "dummy",
                Private = false
            };

            var tripId = await Client.CreateTrip(model);

            tripId.Should().NotBeEmpty();

            var trip = await Client.Get<TripModel>($@"api/trips/{tripId}");

            trip.Title.Should().BeEquivalentTo(model.Title);
            trip.Description.Should().BeEquivalentTo(model.Description);
            trip.Private.Should().Be(model.Private);

            model.Title = "title1";

            await Client.Put($@"api/trips/{tripId}", model);
            trip = await Client.Get<TripModel>($@"api/trips/{tripId}");
            trip.Title.Should().BeEquivalentTo(model.Title);

            await Client.DeleteTrip(tripId);
        }

        [Fact]
        public async void Given_TripDoesNotExist_When_GetById_Expect_BadRequestResponse()
        {
            var tripId = Guid.NewGuid();

            var response = await Client.GetAsync($@"api/trips/{tripId}");

            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
