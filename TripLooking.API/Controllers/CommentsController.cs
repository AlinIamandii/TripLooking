using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Business.Trips.Models.Comment;
using TripLooking.Business.Trips.Services.Interfaces;

namespace TripLooking.API.Controllers
{
    [ApiController]
    [Route("api/v1/trips/{tripId}/comments")]
    [Authorize]
    public sealed class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid tripId)
        {
            var result = await _commentsService.Get(tripId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromRoute] Guid tripId, [FromBody] CreateCommentModel model)
        {
            var result  = await _commentsService.Add(tripId, model);

            return Created(result.Id.ToString(), null);
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> Delete([FromRoute] Guid tripId, [FromRoute] Guid commentId)
        {
            await _commentsService.Delete(tripId, commentId);

            return NoContent();
        }
    }
}