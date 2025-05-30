namespace UpToDo.Domain;

/// <summary>
/// Настройки пользователя.
/// </summary>
public class UserSettings
{
    public Guid Id { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    /// <summary>
    /// Таймзона пользователя.
    /// </summary>
    public int TimeZoneItemId { get; set; }
    public TimeZoneItem TimeZone { get; set; } = null!;

    /// <summary>
    /// Подписан ли пользователь на уведомления компании.
    /// </summary>
    public bool CompanyNotificationsEnabled { get; set; }
}