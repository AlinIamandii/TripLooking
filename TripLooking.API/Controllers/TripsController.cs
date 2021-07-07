﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Business.Trips.Models;
using TripLooking.Business.Trips.Services;
using TripLooking.Persistence;

namespace TripLooking.API.Controllers
{
    [Route("api/[controller]")]
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
            var trip = await tripsService.GetById(id);

            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTripModel model)
        {
            var result = await tripsService.Create(model);

            return Created(result.Id.ToString(), null);
        }
    }
}
