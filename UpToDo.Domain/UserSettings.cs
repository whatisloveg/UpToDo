namespace UpToDo.Domain;

/// <summary>
/// Настройки пользователя.
/// </summary>
public class UserSettings
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public int TimeZoneItemId { get; set; }
    public TimeZoneItem TimeZone { get; set; } = null!;

    public bool CompanyNotificationsEnabled { get; set; }
}