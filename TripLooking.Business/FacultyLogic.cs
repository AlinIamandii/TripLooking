using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TripLooking.Business.Models;
using TripLooking.Database.Models;

namespace TripLooking.Business
{
    public class FacultyLogic
    {
        public List<FacultyBL> GetAllFaculties()
        {
            var ctx = new TripLookingContext();
            var dbUniversityId = (from u in ctx.University
                                  where u.Name.Contains("Ioan Cuza")
                                  select u.Id).FirstOrDefault();

            var dbFaculty = ctx.Faculty
                .Include(u => u.IdUniversityNavigation)
                .Where(f => f.IdUniversity.Equals(dbUniversityId))
                .ToList();

            var facultyList = dbFaculty.Select(el => new FacultyBL()
            {
                Id = el.Id,
                Name = el.Name,
                UniversityName = el.IdUniversityNavigation.Name
            }).ToList();

            return facultyList;
        }
    }
}
