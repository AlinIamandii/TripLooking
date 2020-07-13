using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class UserTrip
    {
        public int Id { get; set; }
        public int IdTrip { get; set; }
        public int IdUser { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
