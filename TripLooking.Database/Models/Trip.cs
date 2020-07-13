using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Notification = new HashSet<Notification>();
            TripComment = new HashSet<TripComment>();
            TripPlace = new HashSet<TripPlace>();
            UserTrip = new HashSet<UserTrip>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public string Link { get; set; }
        public string Notes { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public decimal Capacity { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<TripComment> TripComment { get; set; }
        public virtual ICollection<TripPlace> TripPlace { get; set; }
        public virtual ICollection<UserTrip> UserTrip { get; set; }
    }
}
