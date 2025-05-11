namespace UpToDo.Application.Shared.Common;

/// <summary>
/// Интерфейс хешера паролей
/// </summary>
public interface IPasswordHasher
{
    /// <summary>
    /// Создаёт безопасный хеш из исходного (открытого) пароля.
    /// </summary>
    /// <param name="raw">Открытый пароль пользователя.</param>
    /// <returns>Захешированный пароль для хранения в БД.</returns>
    string Hash(string raw);
    
    /// <summary>
    /// Проверяет, соответствует ли открытый пароль ранее сохранённому хешу.
    /// </summary>
    /// <param name="raw">Открытый пароль, введённый пользователем.</param>
    /// <param name="hash">Хеш пароля из базы данных.</param>
    /// <returns><c>true</c>, если пароли совпадают; иначе <c>false</c>.</returns>
    bool Verify(string raw, string hash);
}