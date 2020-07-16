using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Comment;

namespace TripLooking.Business.Trips.Services.Interfaces
{
    public interface ICommentsService
    {
        Task<IEnumerable<CommentModel>> Get(Guid tripId);

        Task<CommentModel> Add(Guid tripId, CreateCommentModel model);

        Task Delete(Guid tripId, Guid commentId);
    }
}