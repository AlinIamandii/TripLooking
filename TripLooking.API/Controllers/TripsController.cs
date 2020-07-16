using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Business.Trips.Models.Trip;
using TripLooking.Business.Trips.Services.Interfaces;

namespace TripLooking.API.Controllers
{
    [ApiController]
    [Route("api/v1/trips")]
    [Authorize]
    public sealed class TripsController : ControllerBase
    {
        private readonly ITripsService _tripsService;

        public TripsController(ITripsService tripsService)
        {
            _tripsService = tripsService;
        }

        [HttpGet]
        public async Task<IActionResult> Search([FromQuery] SearchModel model)
        {
            var result = await _tripsService.Get(model);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var result = await _tripsService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] UpsertTripModel model)
        {
            var result = await _tripsService.Add(model);
            return Created(result.Id.ToString(), null);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpsertTripModel model)
        {
            await _tripsService.Update(id, model);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _tripsService.Delete(id);

            return NoContent();
        }
    }
}