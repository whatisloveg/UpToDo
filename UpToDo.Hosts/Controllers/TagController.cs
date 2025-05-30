using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.Tags.Commands;
using UpToDo.Application.Tags.Queries;
using UpToDo.Contracts.Tags.Requests;

namespace UpToDo.Hosts.Controllers
{
    [Route("tags")]
    [ApiController]
    [Authorize]
    public class TagController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Guid userId)
        {
            var query = new GetAllUserTagsQuery { UserId = userId };
            var result = await mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetTagByIdQuery { TagId = id };
            var result = await mediator.Send(query);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTagRequest request)
        {
            var command = new CreateTagCommand
            {
                UserId = request.UserId,
                Name = request.Name
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        
        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] UpdateTagRequest request)
        {
            var command = new UpdateTagCommand
            {
                TagId = request.TagId,
                NewTagName = request.NewTagName
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteTagCommand
            {
                TagId = id
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
