using System;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Comments;

namespace TripLooking.Business.Trips.Services.Comments
{
    public interface ICommentsService
    {
        Task<CommentModel> Create(Guid tripId, CreateCommentModel model);
    }
}