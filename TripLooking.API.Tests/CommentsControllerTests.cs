using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using TripLooking.API.Tests.Extensions;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Models.Comments;
using Xunit;

namespace TripLooking.API.Tests
{
    public class CommentsControllerTests: IClassFixture<WebApplicationFactory<Startup>>
    {
        public CommentsControllerTests(WebApplicationFactory<Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        public HttpClient Client { get; }

        [Fact]
        public async void When_GetComments_Expect_ResponseShouldBeSuccessStatusCode()
        {
            var tripId = await Client.CreateTrip(new UpsertTripModel
            {
                Title = "title",
                Description = "dummy",
                Private = false
            });

            await Client.AddComment(tripId, new CreateCommentModel
            {
                Content = "dummy",
                UserId = Guid.NewGuid()
            });

            var result = await Client.GetAsync(@$"api/v1/trips/{tripId}/comments");
            var content = await result.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<CommentModel>>(content);
            Assert.Single(comments);
            Assert.True(result.IsSuccessStatusCode);

            var response = await Client.DeleteAsync(@$"api/v1/trips/{tripId}/comments/{comments.First().Id}");
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);

            response = await Client.DeleteTrip(tripId);
            response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        }
    }
}
