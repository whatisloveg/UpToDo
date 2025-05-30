using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

public class UserSettingsRepository(DataBaseContext context) : IUserSettingsRepository
{
    public async Task<UserSettings?> GetByUserIdAsync(Guid userId, CancellationToken ct = default)
    {
        return await context.UserSettings
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.UserId == userId, ct);
    }

    public async Task AddAsync(UserSettings settings, CancellationToken ct = default)
    {
        await context.UserSettings.AddAsync(settings, ct);
        await context.SaveChangesAsync(ct);
    }

    public async Task UpdateAsync(UserSettings settings, CancellationToken ct = default)
    {
        context.UserSettings.Update(settings);
        await context.SaveChangesAsync(ct);
    }
}