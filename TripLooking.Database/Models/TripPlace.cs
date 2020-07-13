using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class TripPlace
    {
        public TripPlace()
        {
            UserPlace = new HashSet<UserPlace>();
        }

        public int Id { get; set; }
        public int IdTrip { get; set; }
        public int IdPlace { get; set; }

        public virtual Place IdPlaceNavigation { get; set; }
        public virtual Trip IdTripNavigation { get; set; }
        public virtual ICollection<UserPlace> UserPlace { get; set; }
    }
}
