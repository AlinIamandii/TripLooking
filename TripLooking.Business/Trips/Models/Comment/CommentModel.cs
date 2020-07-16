using System;

namespace TripLooking.Business.Trips.Models.Comment
{
    public sealed class CommentModel
    {
        public Guid Id { get; private set; }

        public string Content { get; private set; }

        public Guid UserId { get; private set; }
    }
}