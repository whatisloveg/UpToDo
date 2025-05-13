using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

/// <summary>
/// Репозиторий взаимодействия с сущностью пользователя в БД
/// </summary>
/// <param name="context">Контекст БД</param>
public class UsersRepository(DataBaseContext context) : IUsersRepository
{
    /// <inheritdoc/>
    public async Task AddAsync(User user, CancellationToken ct = default)
    {
        await context.Users.AddAsync(user, ct);
        await context.SaveChangesAsync(ct);
    }

    /// <inheritdoc/>
    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        string normalized = email.Trim().ToLowerInvariant();

        var user = await context.Users
            .FirstOrDefaultAsync(u => u.Email == normalized, ct);
        
        return user;
    }
}