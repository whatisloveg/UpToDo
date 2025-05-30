namespace UpToDo.Domain;

/// <summary>
/// Доменная сущность пользователя.
/// </summary>
/// <param name="name">Имя пользователя.</param>
/// <param name="email">Почта пользователя.</param>
/// <param name="passwordHash">Пароль пользователя.</param>
public class User(string name, string email, string passwordHash)
{
    /// <summary>
    /// Id пользователя.
    /// </summary>
    public Guid Id { get; set; } 
    
    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Name { get; set; } = name;
    
    /// <summary>
    /// Почта пользователя.
    /// </summary>
    public string Email { get; set; } = email;
    
    /// <summary>
    /// Хеш пароля пользователя
    /// </summary>
    public string PasswordHash  { get; set; } = passwordHash;

    /// <summary>
    /// Список задач, принадлежащих пользователю.
    /// </summary>
    public List<TasksList>? TasksLists { get; set; } = new();
    
    /// <summary>
    /// Список тегов принадлежащих пользователю
    /// </summary>
    public List<Tag> Tags { get; set; } = new();
    
    /// <summary>
    /// Настройки пользователя
    /// </summary>
    public UserSettings? Settings { get; set; }
    
    /// <summary>
    /// Отзывы пользователя о приложении
    /// </summary>
    public List<AppReview> AppReviews { get; set; } = new();
}