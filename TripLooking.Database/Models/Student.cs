using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Student
    {
        public Student()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public int IdSpecialization { get; set; }
        public string Name { get; set; }
        public decimal Age { get; set; }
        public decimal Year { get; set; }
        public decimal? PhoneMobile { get; set; }
        public string Email { get; set; }

        public virtual Specialization IdSpecializationNavigation { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
