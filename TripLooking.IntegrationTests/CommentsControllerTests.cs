using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FluentAssertions;
using TripLooking.Business.Trips.Models.Comment;
using TripLooking.Entities.Trips;
using Xunit;

namespace TripLooking.IntegrationTests
{
    public class CommentsControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetsTripComment()
        {
            // Arrange
            var trip = new Trip("Brasov", "Discover Brasov wonders", true);
            var comment = new Comment("comment", AuthenticatedUserId);
            trip.AddComment(comment);
            await ExecuteDatabaseAction(async(tripsContext) =>
            {
                await tripsContext.Trips.AddAsync(trip);
                await tripsContext.SaveChangesAsync();
            });

            //Act
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthenticationToken);
            var response = await HttpClient.GetAsync($"api/v1/trips/{trip.Id}/comments");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<CommentModel>>();
            comments.Should().HaveCount(1);
        }
    }
}
