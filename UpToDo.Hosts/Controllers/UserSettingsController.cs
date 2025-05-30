using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UpToDo.Application.UserSettings.Commands;
using UpToDo.Application.UserSettings.Queries;
using UpToDo.Contracts.UserSettings.Requests;
using UpToDo.Contracts.UserSettings.Responses;

namespace UpToDo.Hosts.Controllers
{
    [Route("user-settings")]
    [ApiController]
    [Authorize]
    public class UserSettingsController(IMediator mediator) : ControllerBase
    {
        /// <summary>
        /// Получить настройки пользователя
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<UserSettingsGetResponse>> Get([FromQuery] Guid userId)
        {
            var query = new GetUserSettingsQuery { UserId = userId };
            var response = await mediator.Send(query);
            return Ok(response);
        }

        /// <summary>
        /// Обновить настройки пользователя
        /// </summary>
        [HttpPatch]
        public async Task<ActionResult<UserSettingsUpdateResponse>> Update([FromBody] UpdateUserSettingsRequest request)
        {
            var command = new UpdateUserSettingsCommand
            {
                UserId = request.UserId,
                TimeZoneItemId = request.TimeZoneItemId,
                CompanyNotificationsEnabled = request.CompanyNotificationsEnabled
            };
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
