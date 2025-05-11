namespace UpToDo.Infrastructure.Identity;

/// <summary>
/// Настройки генерации и валидации JWT‑токенов.
/// </summary>
public class JwtSettings
{
    /// <summary>
    /// Секретный ключ для подписи токена.
    /// </summary>
    public string Key { get; init; } = string.Empty;
    
    /// <summary>
    /// Издатель токена.
    /// </summary>
    public string Issuer { get; init; } = string.Empty;
    
    /// <summary>
    ///  Аудитория токен
    /// </summary>
    public string Audience { get; init; } = string.Empty;
    
    /// <summary>
    ///  Время жизни токена в минутах
    /// </summary>
    public int ExpiresInMinutes { get; set; } 
}