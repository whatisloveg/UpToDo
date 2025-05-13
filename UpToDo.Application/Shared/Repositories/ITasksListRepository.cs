using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

/// <summary>
/// Репозиторий для работы со списками задач.
/// </summary>
public interface ITasksListRepository
{
    /// <summary>
    /// Добавление нового списка задач.
    /// </summary>
    Task AddAsync(TasksList tasksList);

    /// <summary>
    /// Получение списка задач по Id.
    /// </summary>
    Task<TasksList?> GetByIdAsync(Guid id);

    /// <summary>
    /// Получение всех списков задач для пользователя.
    /// </summary>
    Task<List<TasksList>> GetAllByUserIdAsync(Guid userId);

    /// <summary>
    /// Обновление списка задач.
    /// </summary>
    Task UpdateAsync(TasksList tasksList);

    /// <summary>
    /// Удаление списка задач по Id.
    /// </summary>
    Task DeleteAsync(Guid id);
}