using System;

namespace TripLooking.Business.Trips.Models.Photo
{
    public sealed class PhotoModel
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public byte[] PhotoContent { get; private set; }
    }
}