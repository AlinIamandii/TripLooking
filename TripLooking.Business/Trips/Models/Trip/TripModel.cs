using System;

namespace TripLooking.Business.Trips.Models.Trip
{
    public sealed class TripModel
    {
        public Guid Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public bool Private { get; private set; }
    }
}