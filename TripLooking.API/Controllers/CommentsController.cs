using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Business.Trips.Services.Comments;

namespace TripLooking.API.Controllers
{
    [Route("api/v1/trips/{tripId}/comments")]
    [ApiController]
    public class CommentsController : ControllerBase
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
            var result = await this._commentsService.Add(tripId, model);

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
