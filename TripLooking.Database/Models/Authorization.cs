using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class Authorization
    {
        public Authorization()
        {
            RoleAuthorization = new HashSet<RoleAuthorization>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoleAuthorization> RoleAuthorization { get; set; }
    }
}
