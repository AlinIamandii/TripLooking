using System;
using System.Collections.Generic;
using System.Text;

namespace TripLooking.Business.Trips.Models.Comments
{
    public sealed class CommentModel
    {
        public Guid Id { get; set; }

        public string Content { get; set; }
    }
}
