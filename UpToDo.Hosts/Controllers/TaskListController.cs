using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.TasksLists.Commands;
using UpToDo.Application.TasksLists.Queries;
using UpToDo.Contracts.TasksLists.Requests;

namespace UpToDo.Hosts.Controllers
{
    [Route("task-lists")]
    [ApiController]
    [Authorize]
    public class TaskListController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetTasksListByIdQuery(id);
            var tasksList = await mediator.Send(query);
            if (tasksList == null)
                return NotFound();

            return Ok(tasksList);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll([FromQuery] Guid userId)
        {
            var query = new GetAllTasksListsByUserIdQuery(userId);
            var tasksLists = await mediator.Send(query);
            return Ok(tasksLists);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTasksListRequest request)
        {
            var command = new CreateTasksListCommand(request.Name, request.UserId);
            var response = await mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = response.TasksListId }, response);
        }

        [HttpPatch]
        public async Task<IActionResult> Update(UpdateTasksListRequest request)
        {
            if (string.IsNullOrEmpty(request.Id.ToString()))
            {
                return BadRequest("Id не может быть пустым");
            }
            var command = new UpdateTasksListCommand(request.Id, request.Name);
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteTasksListCommand(id);
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
