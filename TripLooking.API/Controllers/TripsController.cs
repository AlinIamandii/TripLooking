using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Persistence;

namespace TripLooking.API.Controllers
{
    [Route("api/v1/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsRepository tripsRepository;

        public TripsController(ITripsRepository tripsRepository)
        {
            this.tripsRepository = tripsRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await tripsRepository.GetTripById(id);

            return Ok(result);
        }
    }
}