using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class User
    {
        public User()
        {
            PlaceComment = new HashSet<PlaceComment>();
            TripComment = new HashSet<TripComment>();
            UserPlace = new HashSet<UserPlace>();
            UserTrip = new HashSet<UserTrip>();
        }

        public int Id { get; set; }
        public int? IdStudent { get; set; }
        public int IdUserType { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }

        public virtual Student IdStudentNavigation { get; set; }
        public virtual UserType IdUserTypeNavigation { get; set; }
        public virtual ICollection<PlaceComment> PlaceComment { get; set; }
        public virtual ICollection<TripComment> TripComment { get; set; }
        public virtual ICollection<UserPlace> UserPlace { get; set; }
        public virtual ICollection<UserTrip> UserTrip { get; set; }
    }
}
