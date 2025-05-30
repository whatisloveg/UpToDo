using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

public interface IUserSettingsRepository
{
    Task<Domain.UserSettings?> GetByUserIdAsync(Guid userId, CancellationToken ct = default);
    Task AddAsync(Domain.UserSettings settings, CancellationToken ct = default);
    Task UpdateAsync(Domain.UserSettings settings, CancellationToken ct = default);
}