﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Comments;

namespace TripLooking.Business.Trips.Services.Comments
{
    public interface ICommentsService
    {
        Task<CommentModel> Add(Guid tripId, CreateCommentModel model);

        Task<IEnumerable<CommentModel>> Get(Guid tripId);

        Task Delete(Guid tripId, Guid commentId);
    }
}
