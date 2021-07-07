using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Comments;

namespace TripLooking.Business.Trips.Services.Comments
{
    public interface ICommentsService
    {
        Task<CommentModel> Create(Guid tripId, CreateCommentModel model);
    }
}
