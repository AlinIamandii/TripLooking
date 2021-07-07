using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services.Comments
{
    public sealed class CommentsService : ICommentsService
    {
        private readonly ITripsRepository tripsRepository;
        private readonly IMapper mapper;

        public CommentsService(ITripsRepository tripsRepository, IMapper mapper)
        {
            this.tripsRepository = tripsRepository;
            this.mapper = mapper;
        }

        public async Task<CommentModel> Create(Guid tripId, CreateCommentModel model)
        {
            var trip = await tripsRepository.GetTripById(tripId);

            //var comment = mapper.Map<Comment>(model);
            var comment = new Comment(model.Content, Guid.NewGuid());

            trip.Comments.Add(comment);
            await tripsRepository.SaveChanges();

            return mapper.Map<CommentModel>(comment);
        }
    }
}
