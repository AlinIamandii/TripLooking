using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class University
    {
        public University()
        {
            Faculty = new HashSet<Faculty>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public virtual ICollection<Faculty> Faculty { get; set; }
    }
}
