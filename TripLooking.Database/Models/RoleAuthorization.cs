using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class RoleAuthorization
    {
        public int Id { get; set; }
        public int IdUserType { get; set; }
        public int IdAuthorization { get; set; }

        public virtual Authorization IdAuthorizationNavigation { get; set; }
    }
}
