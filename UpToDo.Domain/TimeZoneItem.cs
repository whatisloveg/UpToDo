namespace UpToDo.Domain;

public class TimeZoneItem
{
    /// <summary>
    /// Уникальный числовой идентификатор таймзоны.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Техническое имя таймзоны (например, "Europe/Moscow").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Человекочитаемое имя таймзоны (например, "(UTC+03:00) Москва").
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Отклонение по UTC в часах (например, 3, -5).
    /// </summary>
    public int UtcOffset { get; set; }
}