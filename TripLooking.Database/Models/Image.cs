using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Image
    {
        public Image()
        {
            Place = new HashSet<Place>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Place> Place { get; set; }
    }
}
