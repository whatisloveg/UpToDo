namespace UpToDo.Domain;

public class AppReview
{
    /// <summary>
    /// Уникальный идентификатор отзыва.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Id пользователя, оставившего отзыв.
    /// </summary>
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    /// <summary>
    /// Оценка приложения (от 1 до 10).
    /// </summary>
    public int Rating { get; set; }

    /// <summary>
    /// Текст комментария пользователя.
    /// </summary>
    public string? Comment { get; set; }
}