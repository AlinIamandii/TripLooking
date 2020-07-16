using System;

namespace TripLooking.Entities.Trips
{
    public sealed class Comment : Entity
    {
        public Comment(string content, Guid userId) : base()
        {
            Content = content;
            UserId = userId;
        }

        public string Content { get; private set; }
        
        public Guid UserId { get; private set; }
    }
}