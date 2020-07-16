using AutoMapper;

namespace TripLooking.Business.Trips.Models.Trip
{
    public sealed class UpsertTripModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
    }
}