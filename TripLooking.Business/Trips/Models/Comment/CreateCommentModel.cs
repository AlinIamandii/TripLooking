using System;
using System.Text.Json.Serialization;

namespace TripLooking.Business.Trips.Models.Comment
{
    public sealed class CreateCommentModel
    {
        public string Content { get; set; }

        [JsonIgnore]
        public Guid UserId { get; set; }
    }
}