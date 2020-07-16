using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Services;

namespace TripLooking.API.Controllers
{
    [Route("api/v1/trips")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await tripsService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTripModel model)
        {
            var result = await tripsService.Create(model);

            return Created(result.Id.ToString(), null);
        }
    }
}