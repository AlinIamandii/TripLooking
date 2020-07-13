using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Notification
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}
