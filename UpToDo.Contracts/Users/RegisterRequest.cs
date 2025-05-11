namespace UpToDo.Contracts.Users;

/// <summary>
/// Запрос регистрации пользователя
/// </summary>
/// <param name="Name">Имя пользователя.</param>
/// <param name="Email">Почта пользователя.</param>
/// <param name="Password">Пароль пользователя.</param>
/// <param name="ConfirmPassword">Повтор пароля пользователя.</param>
public sealed record RegisterRequest(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword);