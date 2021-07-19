using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentAssertions;
using Moq;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Business.Trips.Services.Comments;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;
using Xunit;

namespace TripLooking.Business.Tests
{
    public class CommentsServiceTest : IDisposable
    {
        private MockRepository MockRepository;
        private Mock<ITripsRepository> _tripsRepositoryMock;
        private Mock<IMapper> _mapperMock;

        private CommentsService SUT;

        public CommentsServiceTest()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);

            _tripsRepositoryMock = MockRepository.Create<ITripsRepository>();
            _mapperMock = MockRepository.Create<IMapper>();

            SUT = new CommentsService(_tripsRepositoryMock.Object, _mapperMock.Object);
        }

        public void Dispose()
        {
            MockRepository.VerifyAll();
        }

        [Fact]
        public async void When_Get_IsCalled_Expect_CommentsToBeReturned()
        {
            // Arrange
            var trip = new Trip("Title", "Description", false);
            trip.Comments.Add(new Comment("comm1", Guid.NewGuid()));
            trip.Comments.Add(new Comment("comm2", Guid.NewGuid()));

            var expectedResult = trip.Comments.Select(c => new CommentModel()
            {
                Content = c.Content,
                Id = c.Id
            });

            _tripsRepositoryMock
                .Setup(t => t.GetTripById(trip.Id))
                .ReturnsAsync(trip);

            _mapperMock
                .Setup(m => m.Map<IEnumerable<CommentModel>>(trip.Comments))
                .Returns(expectedResult);

            // Act
            var result = await SUT.Get(trip.Id);

            // Assert
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
