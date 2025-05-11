using UpToDo.Domain;

namespace UpToDo.Application.Shared.Common;

/// <summary>
/// Интерфейс генератора jwt токенов
/// </summary>
public interface IJwtTokenGenerator
{
    /// <summary>
    /// Генерирует подписанный JWT-токен для указанного пользователя.
    /// </summary>
    /// <param name="user">Пользователь, для которого создаётся токен.</param>
    /// <returns>Строка с access-токеном (JWT).</returns>
    string Generate(User user);
}