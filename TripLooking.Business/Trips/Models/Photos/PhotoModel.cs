using System;

namespace TripLooking.Business.Trips.Models.Photos
{
    public sealed class PhotoModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public byte[] PhotoContent { get; set; }
    }
}