using MediatR;
using UpToDo.Contracts.UserSettings.Responses;

namespace UpToDo.Application.UserSettings.Commands;

public class UpdateUserSettingsCommand: IRequest<UserSettingsUpdateResponse>
{
    public Guid UserId { get; set; }
    public int? TimeZoneItemId { get; set; }
    public bool? CompanyNotificationsEnabled { get; set; }
}