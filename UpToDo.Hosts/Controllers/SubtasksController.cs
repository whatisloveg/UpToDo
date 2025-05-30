using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.Subtasks.Commands;
using UpToDo.Application.Subtasks.Queries;
using UpToDo.Application.TasksLists.Commands;
using UpToDo.Contracts.Subtasks.Requests;

namespace UpToDo.Hosts.Controllers
{
    [Route("subtasks")]
    [ApiController]
    public class SubtasksController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBySubtaskId([FromQuery] Guid id)
        {
            var query = new GetSubtaskByIdQuery()
            {
                Id = id
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
        
        [HttpGet("task")]
        public async Task<IActionResult> GetSubtasksByTaskId([FromQuery] Guid taskId)
        {
            var query = new GetSubtasksByTaskIdQuery()
            {
                TaskId = taskId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSubtaskRequest request)
        {
            var command = new CreateSubtaskCommand()
            {
                Name = request.Name, 
                ToDoTaskId = request.ToDoTaskId
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateSubtaskRequest request)
        {
            if (string.IsNullOrEmpty(request.Id.ToString()))
            {
                return BadRequest("Id не может быть пустым");
            }
            var command = new UpdateSubtaskCommand()
            {
                Id = request.Id,
                Name = request.Name,
                IsCompleted = request.IsCompleted
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteSubtaskCommand()
            {
                Id = id
            };
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
