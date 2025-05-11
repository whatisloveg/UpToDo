using UpToDo.Application.Shared.Common;

namespace UpToDo.Infrastructure.Identity;

/// <summary>
/// Хешер паролей
/// </summary>
public class BcryptHasher : IPasswordHasher
{
    /// <inheritdoc/>
    public string Hash(string raw)
    {
        return BCrypt.Net.BCrypt.HashPassword(raw);
    }

    /// <inheritdoc/>
    public bool Verify(string raw, string hash)
    {
        return BCrypt.Net.BCrypt.Verify(raw, hash);
    }
}