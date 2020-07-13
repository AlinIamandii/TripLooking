using System;
using System.Collections.Generic;

namespace TripLooking.Database.Models
{
    public partial class PlaceComment
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string Comment { get; set; }
        public string Review { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
