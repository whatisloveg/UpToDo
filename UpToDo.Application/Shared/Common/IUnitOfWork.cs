namespace UpToDo.Application.Shared.Common;

/// <summary>
/// Интерфейс для шаблона Unit of Work.
/// Обеспечивает атомарное сохранение всех изменений в рамках текущего бизнес-транзакционного контекста.
/// Вызывается после завершения операций репозиториев.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Подтверждает все накопленные изменения и сохраняет их в базу данных.
    /// </summary>
    Task CommitAsync(CancellationToken ct = default);
}