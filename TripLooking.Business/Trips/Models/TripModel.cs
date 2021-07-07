using System;

namespace TripLooking.Business.Trips.Models
{
    public class TripModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}