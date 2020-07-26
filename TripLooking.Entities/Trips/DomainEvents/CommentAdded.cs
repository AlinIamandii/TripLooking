using System;

namespace TripLooking.Entities.Trips.DomainEvents
{
    public class CommentAdded : IDomainEvent
    {
        public CommentAdded(Guid userId)
        {
            UserId = userId;
        }

        public Guid UserId { get; private set; }
    }
}
