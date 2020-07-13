using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Faculty
    {
        public Faculty()
        {
            Specialization = new HashSet<Specialization>();
        }

        public int Id { get; set; }
        public int IdUniversity { get; set; }
        public string Name { get; set; }

        public virtual University IdUniversityNavigation { get; set; }
        public virtual ICollection<Specialization> Specialization { get; set; }
    }
}
