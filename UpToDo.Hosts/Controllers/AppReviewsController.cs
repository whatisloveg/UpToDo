using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.AppReviews.Commands;
using UpToDo.Contracts.AppReviews.Requests;
using UpToDo.Contracts.AppReviews.Responses;

namespace UpToDo.Hosts.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppReviewsController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Создать отзыв о приложении
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CreateAppReviewResponse>> Create([FromBody] CreateAppReviewRequest request)
        {
            var command = new CreateAppReviewCommand
            {
                UserId = request.UserId,
                Rating = request.Rating,
                Comment = request.Comment
            };

            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
