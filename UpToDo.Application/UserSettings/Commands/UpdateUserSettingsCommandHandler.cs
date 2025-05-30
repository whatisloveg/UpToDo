using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.UserSettings.Responses;

namespace UpToDo.Application.UserSettings.Commands;

public class UpdateUserSettingsCommandHandler(IUserSettingsRepository repository)
    : IRequestHandler<UpdateUserSettingsCommand, UserSettingsUpdateResponse>
{
    public async Task<UserSettingsUpdateResponse> Handle(UpdateUserSettingsCommand request, CancellationToken cancellationToken)
    {
        var settings = await repository.GetByUserIdAsync(request.UserId, cancellationToken);
        if (settings == null)
            throw new UserNotFoundException();

        if (request.TimeZoneItemId.HasValue)
            settings.TimeZoneItemId = request.TimeZoneItemId.Value;

        if (request.CompanyNotificationsEnabled.HasValue)
            settings.CompanyNotificationsEnabled = request.CompanyNotificationsEnabled.Value;

        await repository.UpdateAsync(settings, cancellationToken);

        return new UserSettingsUpdateResponse(true);
    }
}