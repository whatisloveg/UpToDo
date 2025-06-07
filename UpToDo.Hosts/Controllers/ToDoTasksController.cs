using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.Tasks.Commands;
using UpToDo.Application.Tasks.Queries;
using UpToDo.Contracts.Tasks.Requests;

namespace UpToDo.Hosts.Controllers
{
    [Route("tasks")]
    [ApiController]
    public class ToDoTasksController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Создание новой задачи.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateToDoTaskRequest request)
        {
            var command = new CreateToDoTaskCommand
            {
                Name = request.Name,
                TasksListId = request.TasksListId
            };

            var response = await mediator.Send(command);
            return Ok(response.TaskId);
        }

        /// <summary>
        /// Получение задачи по ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = new GetToDoTaskByIdQuery { Id = id };
            var response = await mediator.Send(request);
            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
        /// Обновление задачи.
        /// </summary>
        [HttpPatch]
        public async Task<IActionResult> Update(UpdateToDoTaskRequest request)
        {
            if (string.IsNullOrEmpty(request.Id.ToString()))
            {
                return BadRequest("Id - обязательный параметр");
            }
            var command = new UpdateToDoTaskCommand
            {   
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                EstimatedTime = request.EstimatedTime,
                IsCompleted = request.IsCompleted,
                MatrixPriority = request.MatrixPriority
            };

            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Удаление задачи.
        /// </summary>  
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteToDoTaskCommand { Id = id };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Получение всех задач в списке.
        /// </summary>
        [HttpGet("list")]
        public async Task<IActionResult> GetAll(Guid tasksListId)
        {
            var query = new GetAllToDoTasksQuery { TasksListId = tasksListId };
            var response = await mediator.Send(query);
            return Ok(response);
        }
        
        
        /// <summary>
        /// Добавить тег к задаче
        /// </summary>
        [HttpPost("{taskId}/tags/{tagId}")]
        public async Task<IActionResult> AddTagToTask([FromRoute] Guid taskId, [FromRoute] Guid tagId)
        {
            var command = new AddTagToTaskToTagCommand
            {
                TaskId = taskId,
                TagId = tagId
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Удалить тег из задачи
        /// </summary>
        [HttpDelete("{taskId}/tags/{tagId}")]
        public async Task<IActionResult> RemoveTagFromTask([FromRoute] Guid taskId, [FromRoute] Guid tagId)
        {
            var command = new RemoveTagFromTaskCommand
            {
                TaskId = taskId,
                TagId = tagId
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }

        /// <summary>
        /// Получить теги задачи
        /// </summary>
        [HttpGet("{taskId}/tags")]
        public async Task<IActionResult> GetTaskTags([FromRoute] Guid taskId)
        {
            var query = new GetTaskTagsQuery { TaskId = taskId };
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
