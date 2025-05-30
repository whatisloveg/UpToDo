namespace UpToDo.Contracts.UserSettings.Requests;

public record UpdateUserSettingsRequest(
    Guid UserId,
    int? TimeZoneItemId,
    bool? CompanyNotificationsEnabled
);