using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

/// <summary>
/// Интерфейс репозитория для задач.
/// </summary>
public interface IToDoTaskRepository
{
    /// <summary>
    /// Добавление новой задачи.
    /// </summary>
    Task AddAsync(ToDoTask task);

    /// <summary>
    /// Получение задачи по Id.
    /// </summary>
    Task<ToDoTask?> GetByIdAsync(Guid id);

    /// <summary>
    /// Получение всех задач для указанного списка задач.
    /// </summary>
    Task<List<ToDoTask>> GetAllByTasksListIdAsync(Guid tasksListId);

    /// <summary>
    /// Обновление задачи.
    /// </summary>
    Task UpdateAsync(ToDoTask task);

    /// <summary>
    /// Удаление задачи по Id.
    /// </summary>
    Task DeleteAsync(Guid id);
}