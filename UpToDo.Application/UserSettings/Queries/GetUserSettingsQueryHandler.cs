using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.UserSettings.Responses;

namespace UpToDo.Application.UserSettings.Queries;

public class GetUserSettingsQueryHandler(IUserSettingsRepository repository)
    : IRequestHandler<GetUserSettingsQuery, UserSettingsGetResponse>
{
    public async Task<UserSettingsGetResponse> Handle(GetUserSettingsQuery request, CancellationToken cancellationToken)
    {
        var settings = await repository.GetByUserIdAsync(request.UserId, cancellationToken);
        if (settings == null)
            throw new UserNotFoundException();

        return new UserSettingsGetResponse(
            settings.UserId,
            settings.TimeZoneItemId,
            settings.CompanyNotificationsEnabled
        );
    }
}