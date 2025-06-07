namespace UpToDo.Contracts.Users;

/// <summary>
/// Ответ сервера на авторизацию и регистрацию
/// </summary>
/// <param name="AccessToken">JWT токен авторизации</param>
public sealed record TokenResponse(
    string AccessToken, Guid UserId, string UserName, string Email);