using System;
using System.Collections.Generic;
using System.Linq;
using TripLooking.Entities.Trips.DomainEvents;

namespace TripLooking.Entities.Trips
{
    public sealed class Trip : Entity
    {
        public Trip(string title, string description, bool @private) :base()
        {
            Title = title;
            Description = description;
            Private = @private;
            Photos = new List<Photo>();
            Comments = new List<Comment>();
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public bool Private { get; private set; }
        
        public ICollection<Photo> Photos { get; private set; }

        public ICollection<Comment> Comments { get; private set; }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
            DomainEvents.Add(new CommentAdded(comment.UserId));
        }

        public void RemoveComment(Guid commentId)
        {
            var comment = this.Comments.FirstOrDefault(c => c.Id == commentId);
            
            if(comment != null)
            {
                this.Comments.Remove(comment);
            }
        }

        public void Update(string title, string description, bool @private)
        {
            Title = title;
            Description = description;
            Private = @private;
        }
    }
}