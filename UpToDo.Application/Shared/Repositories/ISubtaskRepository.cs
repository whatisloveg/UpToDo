using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

/// <summary>
/// Интерфейс репозитория для сущности Subtask.
/// </summary>
public interface ISubtaskRepository
{
    /// <summary>
    /// Добавление подзадачи.
    /// </summary>
    Task AddAsync(Subtask subtask);

    /// <summary>
    /// Получение подзадачи по Id.
    /// </summary>
    Task<Subtask?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Получение подзадач по Id todoTask.
    /// </summary>
    Task<List<Subtask>> GetByTodoTaskAsync(Guid toDoTaskId);

    /// <summary>
    /// Обновление подзадачи.
    /// </summary>
    Task UpdateAsync(Subtask subtask);

    /// <summary>
    /// Удаление подзадачи по Id.
    /// </summary>
    Task DeleteAsync(Guid id);
}