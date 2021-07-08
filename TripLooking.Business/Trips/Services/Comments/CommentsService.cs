using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Entities.Trips;
using TripLooking.Persistence;

namespace TripLooking.Business.Trips.Services.Comments
{
    public sealed class CommentsService : ICommentsService
    {
        private readonly ITripsRepository _tripsRepository;
        private readonly IMapper _mapper;

        public CommentsService(ITripsRepository tripsRepository, IMapper mapper)
        {
            _tripsRepository = tripsRepository;
            _mapper = mapper;
        }

        public async Task<CommentModel> Add(Guid tripId, CreateCommentModel model)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            var comment = _mapper.Map<Comment>(model);
            trip.Comments.Add(comment);

            _tripsRepository.Update(trip);
            await _tripsRepository.SaveChanges();

            return _mapper.Map<CommentModel>(comment);
        }

        public async Task<IEnumerable<CommentModel>> Get(Guid tripId)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            return _mapper.Map<IEnumerable<CommentModel>>(trip.Comments);
        }

        public async Task Delete(Guid tripId, Guid commentId)
        {
            var trip = await _tripsRepository.GetTripById(tripId);

            var commentToRemove = trip.Comments.FirstOrDefault(c => c.Id == commentId);

            if (commentToRemove != null)
            {
                trip.Comments.Remove(commentToRemove);
            }

            _tripsRepository.Update(trip);

            await _tripsRepository.SaveChanges();
        }
    }
}
