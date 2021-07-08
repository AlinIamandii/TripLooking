using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Photos;
using TripLooking.Business.Trips.Services.Photos;

namespace TripLooking.API.Controllers
{
    [Route("api/v1/trips/{tripId}/photos")]
    [ApiController]
    public sealed class PhotosController : ControllerBase
    {
        private readonly IPhotosService _photosService;

        public PhotosController(IPhotosService photosService)
        {
            _photosService = photosService;
        }

        [HttpGet("{photoId}")]
        public async Task<IActionResult> GetById([FromRoute] Guid tripId, [FromRoute] Guid photoId)
        {
            var result = await _photosService.GetById(tripId, photoId);

            if (result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid tripId)
        {
            var result = await _photosService.Get(tripId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid tripId, [FromForm] CreatePhotoModel model)
        {
            var result = await _photosService.Add(tripId, model);

            return Created(result.Id.ToString(), null);
        }
    }
}
