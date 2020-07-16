using System.Collections.Generic;

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
        }
    }
}