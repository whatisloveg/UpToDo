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
    /// Хеш паролья пользователя
    /// </summary>
    public string PasswordHash  { get; set; } = passwordHash;
}