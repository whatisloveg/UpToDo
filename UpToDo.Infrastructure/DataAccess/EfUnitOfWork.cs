using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Common;

namespace UpToDo.Infrastructure.DataAccess;

/// <summary>
/// Реализация шаблона Unit of Work на основе Entity Framework Core.
/// Отвечает за единое сохранение изменений через DbContext.
/// </summary>
public class EfUnitOfWork(DataBaseContext dbContext) : IUnitOfWork
{
    /// <inheritdoc/>
    public Task CommitAsync(CancellationToken ct = default)
    {
        return dbContext.SaveChangesAsync(ct);
    }
}