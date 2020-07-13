using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Specialization
    {
        public Specialization()
        {
            Student = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int IdFaculty { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual Faculty IdFacultyNavigation { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
