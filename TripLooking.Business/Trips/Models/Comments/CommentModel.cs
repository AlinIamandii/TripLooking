using System;

namespace TripLooking.Business.Trips.Models.Comments
{
    public sealed class CommentModel
    {
        public Guid Id { get; private set; }

        public string Content { get; private set; }
    }
}