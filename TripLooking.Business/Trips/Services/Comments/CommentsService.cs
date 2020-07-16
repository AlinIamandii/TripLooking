using System;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services.Comments
{
    public sealed class CommentsService : ICommentsService
    {
        private readonly ITripsRepository repository;
        private readonly IMapper mapper;

        public CommentsService(ITripsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<CommentModel> Create(Guid tripId, CreateCommentModel model)
        {
            var comment = new Comment(model.Content, Guid.NewGuid());

            var trip = await repository.GetTripById(tripId);
            trip.AddComment(comment);

            repository.Update(trip);
            await repository.SaveChanges();

            return mapper.Map<CommentModel>(comment);
        }
    }
}