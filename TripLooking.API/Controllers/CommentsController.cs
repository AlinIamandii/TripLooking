using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TripLooking.Business.Trips.Models.Comments;
using TripLooking.Business.Trips.Services.Comments;

namespace TripLooking.API.Controllers
{
    [ApiController]
    [Route("api/v1/trips/{tripId}/comments")]
    public sealed class CommentsController : ControllerBase
    {
        private readonly ICommentsService commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost()]
        public async Task<IActionResult> Create([FromRoute] Guid tripId, [FromBody] CreateCommentModel model)
        {
            var result = await this.commentsService.Create(tripId, model);

            return Created(result.Id.ToString(), null);
        }
    }
}
