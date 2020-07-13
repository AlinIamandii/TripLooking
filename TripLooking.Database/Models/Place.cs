using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Place
    {
        public Place()
        {
            TripPlace = new HashSet<TripPlace>();
        }

        public int Id { get; set; }
        public int? IdImage { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }

        public virtual Image IdImageNavigation { get; set; }
        public virtual ICollection<TripPlace> TripPlace { get; set; }
    }
}
