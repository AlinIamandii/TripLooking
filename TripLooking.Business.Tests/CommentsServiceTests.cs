using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CommentsServiceTests : TestsBase<CommentsService>
    {
        private Mock<ITripsRepository> _tripsRepository;
        private Mock<IMapper> _mapper;

        protected override void CreateMocks()
        {
            _tripsRepository = MockRepository.Create<ITripsRepository>();
            _mapper = MockRepository.Create<IMapper>();
        }

        protected override CommentsService CreateSUT() =>
            new CommentsService(_tripsRepository.Object, _mapper.Object);

        [Fact]
        public async void When_AddIsCalled_ExpectGetTripByIdAndUpdateAndSaveChangesFromRepoToBeCalled_AndReturnMappedResult()
        {
            var trip = new Trip("dummy", "dummy", false);
            var createCommentModel = new CreateCommentModel
            {
                Content = "dummy1",
                UserId = Guid.NewGuid()
            };

            var comment = new Comment(createCommentModel.Content, createCommentModel.UserId);

            var commentModel = new CommentModel
            {
                Content = createCommentModel.Content,
                Id = Guid.NewGuid()
            };

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _mapper.Setup(mock => mock.Map<Comment>(createCommentModel)).Returns(comment);
            _tripsRepository.Setup(mock => mock.Update(trip));
            _tripsRepository.Setup(mock => mock.SaveChanges()).Returns(Task.CompletedTask);
            _mapper.Setup(mock => mock.Map<CommentModel>(comment)).Returns(commentModel);

            var result = await SUT.Add(trip.Id, createCommentModel);

            result.Should().BeEquivalentTo(commentModel);
        }

        [Fact]
        public async void When_GetIsCalled_ExpectGetTripByIdFromRepoToBeCalled_AndReturnMappedResult()
        {
            var trip = new Trip("dummy", "dummy", false);

            trip.Comments.Add(new Comment("dummy1", Guid.NewGuid()));
            trip.Comments.Add(new Comment("dummy2", Guid.NewGuid()));

            var expectedResult = trip.Comments.Select(t => new CommentModel
            {
                Content = t.Content,
                Id = Guid.NewGuid()
            }).ToList();

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _mapper.Setup(mock => mock.Map<IEnumerable<CommentModel>>(trip.Comments)).Returns(expectedResult.AsEnumerable());
            var result = await SUT.Get(trip.Id);

            result.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public async void
            When_DeleteIsCalled_ExpectInvokeGetTripByIdFromRepo_And_DeleteAllComments_AndInvokeUpdateAndSaveChangesFromRepo()
        {
            var trip = new Trip("dummy", "dummy", false);
            trip.Comments.Add(new Comment("dummy1", Guid.NewGuid()));
            trip.Comments.Add(new Comment("dummy2", Guid.NewGuid()));

            _tripsRepository.Setup(mock => mock.GetTripById(trip.Id)).Returns(Task.FromResult(trip));
            _tripsRepository.Setup(mock => mock.Update(It.IsAny<Trip>()))
                .Callback((Trip x) =>
                {
                    x.Comments.Count.Should().Be(1);
                    x.Comments.First().Content.Should().BeEquivalentTo("dummy2");
                });

            _tripsRepository.Setup(mock => mock.SaveChanges()).Returns(Task.CompletedTask);

            await SUT.Delete(trip.Id, trip.Comments.First().Id);
        }
    }
}
