using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.AspNetCore.Http;
using TripLooking.Business.Trips.Models.Comment;
using TripLooking.Business.Trips.Services.Interfaces;
using TripLooking.Entities.Trips;
using TripLooking.Persistence.Trips;

namespace TripLooking.Business.Trips.Services.Implementations
{
    public sealed class CommentsService : ICommentsService
    {
        private readonly ITripsRepository _repository;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _accessor;

        public CommentsService(ITripsRepository repository, IMapper mapper, IHttpContextAccessor accessor)
        {
            _repository = repository;
            _mapper = mapper;
            _accessor = accessor;
        }

        public async Task<IEnumerable<CommentModel>> Get(Guid tripId)
        {
            var trip = await _repository.GetByIdWithComments(tripId);

            return _mapper.Map<IEnumerable<CommentModel>>(trip.Comments);
        }

        public async Task<CommentModel> Add(Guid tripId, CreateCommentModel model)
        {
            model.UserId = Guid.Parse(_accessor.HttpContext.User.Claims.First(c => c.Type == "userId").Value);
            var comment = _mapper.Map<Comment>(model);
            var trip = await _repository.GetById(tripId);

            trip.AddComment(comment);

            _repository.Update(trip);
            await _repository.SaveChanges();

            return _mapper.Map<CommentModel>(comment);
        }

        public async Task Delete(Guid tripId, Guid commentId)
        {
            var trip = await _repository.GetByIdWithComments(tripId);

            trip.RemoveComment(commentId);
            _repository.Update(trip);

            await _repository.SaveChanges();
        }
    }
}