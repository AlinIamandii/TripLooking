using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TripLooking.Business;
using TripLooking.Business.Models;
using TripLooking.Database;

namespace TripLooking.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FacultyListController : ControllerBase
    {
        private ILogger<FacultyListController> _logger;

        public FacultyListController(ILogger<FacultyListController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<FacultyBL> Get()
        {
            var facultyLogic = new FacultyLogic();
            return facultyLogic.GetAllFaculties();
        }
    }
}
