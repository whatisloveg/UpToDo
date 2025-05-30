namespace UpToDo.Contracts.UserSettings.Responses;

public record UserSettingsGetResponse(
    Guid UserId,
    int TimeZoneItemId,
    bool CompanyNotificationsEnabled
);