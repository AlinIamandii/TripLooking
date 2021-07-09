using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
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
            var tripId = await CreateTrip();
            await AddComment(tripId);
            var result = await Client.GetAsync(@$"api/v1/trips/{tripId}/comments");
            var content = await result.Content.ReadAsStringAsync();
            var comments = JsonConvert.DeserializeObject<List<CommentModel>>(content);
            await DeleteTrip(tripId);
            Assert.Single(comments);
            Assert.True(result.IsSuccessStatusCode);
        }

        private async Task<Guid> CreateTrip()
        {
            var model = new UpsertTripModel
            {
                Title = "title",
                Description = "dummy",
                Private = false
            };

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(@"api/trips", content);

            return Guid.Parse(response.Headers.Location.ToString());
        }

        private async Task DeleteTrip(Guid id)
        {
            await Client.DeleteAsync(@$"api/trips/{id}");
        }

        private async Task<Guid> AddComment(Guid tripId)
        {
            var model = new CreateCommentModel
            {
                Content = "dummy",
                UserId = Guid.NewGuid()
            };

            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await Client.PostAsync(@$"api/v1/trips/{tripId}/comments", content);

            return Guid.Parse(response.Headers.Location.ToString());
        }
    }
}
