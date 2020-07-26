using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using TripLooking.Business.Trips.Models.Comment;
using TripLooking.Entities.Trips;
using Xunit;

namespace TripLooking.IntegrationTests
{
    public class CommentsControllerTests : IntegrationTests
    {
        [Fact]
        public async Task GetTripComment()
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
            var response = await HttpClient.GetAsync($"api/v1/trips/{trip.Id}/comments");

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var comments = await response.Content.ReadAsAsync<IList<CommentModel>>();
            comments.Should().HaveCount(1);
        }
        
        [Fact]
        public async Task AddCommentToTrip()
        {
            // Arrange
            var trip = new Trip("Brasov", "Discover Brasov wonders", true);
            await ExecuteDatabaseAction(async(tripsContext) =>
            {
                await tripsContext.Trips.AddAsync(trip);
                await tripsContext.SaveChangesAsync();
            });
            var createCommentModel = new CreateCommentModel
            {
                Content = "comment",
                UserId = AuthenticatedUserId
            };

            //Act
            var response = await HttpClient.PostAsJsonAsync($"api/v1/trips/{trip.Id}/comments", createCommentModel);

            // Assert
            response.IsSuccessStatusCode.Should().BeTrue();
            var createdCommentId = response.Headers.Location.OriginalString;
            Comment existingComment = null;
            await ExecuteDatabaseAction(async(tripsContext) =>
                {
                    var existingTrip = await tripsContext.Trips
                        .Include(entity => entity.Comments)
                        .FirstAsync(entity => entity.Id == trip.Id);
                    existingComment = existingTrip.Comments.FirstOrDefault();
                });
            existingComment.Should().NotBeNull();
            existingComment.Id.Should().Be(createdCommentId);

            MockLogger.Verify(x => x.LogCommentAdded(AuthenticatedUserId), Times.Once);
        }
    }
}
