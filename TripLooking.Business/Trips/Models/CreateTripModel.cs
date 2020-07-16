using System;
using System.Collections.Generic;
using System.Text;

namespace TripLooking.Business.Trips.Models
{
    public sealed class CreateTripModel
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public bool Private { get; set; }
    }
}
