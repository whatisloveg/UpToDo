using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UpToDo.Hosts.Controllers
{
    [Route("task-lists")]
    [ApiController]
    [Authorize]
    public class TaskListController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(new { listId = 1, tasksCount = 4 });
        }

    }
}
