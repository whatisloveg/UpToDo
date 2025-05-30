using MediatR;
using UpToDo.Contracts.UserSettings.Responses;

namespace UpToDo.Application.UserSettings.Queries;

public class GetUserSettingsQuery: IRequest<UserSettingsGetResponse>
{
    public Guid UserId { get; set; }
}