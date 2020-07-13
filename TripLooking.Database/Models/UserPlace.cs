using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class UserPlace
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdTripPlace { get; set; }

        public virtual TripPlace IdTripPlaceNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
