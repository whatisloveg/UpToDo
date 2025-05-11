using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

/// <summary>
/// Репозиторий для работы с сущностью пользователя <see cref="User"/>.
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Добавляет нового пользователя.
    /// </summary>
    /// <param name="user">Сущность пользователя.</param>
    /// <param name="ct">Токен отмены</param>
    Task AddAsync(User user, CancellationToken ct = default);
    
    /// <summary>
    /// Возвращает пользователя по email, если он существует. В противном случае — <c>null</c>.
    /// </summary>
    /// <param name="email">Email пользователя.</param>
    /// <param name="ct">Токен отмены операции.</param>
    /// <returns>Сущность пользователя</returns>
    Task<User?> GetByEmailAsync(string email, CancellationToken ct = default);
}