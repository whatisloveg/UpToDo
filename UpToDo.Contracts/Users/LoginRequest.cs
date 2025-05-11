namespace UpToDo.Contracts.Users;

/// <summary>
/// Запрос авторизации пользователя.
/// </summary>
/// <param name="Email">Почта пользователя.</param>
/// <param name="Password">Пароль пользователя.</param>
public sealed record LoginRequest(
    string Email,
    string Password);