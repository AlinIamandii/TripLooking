using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Services;

namespace TripLooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var trips = _tripsService.GetAll();

            return Ok(trips);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var trip = await _tripsService.GetById(id);

            if (trip == null)
            {
                return BadRequest();
            }

            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UpsertTripModel model)
        {
            var result = await _tripsService.Create(model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _tripsService.Delete(id);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertTripModel model)
        {
            await _tripsService.Update(id, model);

            return NoContent();
        }
    }
}
