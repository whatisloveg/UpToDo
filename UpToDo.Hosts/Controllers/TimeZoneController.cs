using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.TimeZones.Queries;
using UpToDo.Contracts.TimeZones.Responses;

namespace UpToDo.Hosts.Controllers
{
    [Route("time-zone")]
    [ApiController]
    public class TimeZoneController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Получить все таймзоны.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<List<TimeZoneItemResponse>>> GetAll()
        {
            var query = new GetAllTimeZoneItemsQuery();
            var response = await mediator.Send(query);
            return Ok(response);
        }
    }
}
