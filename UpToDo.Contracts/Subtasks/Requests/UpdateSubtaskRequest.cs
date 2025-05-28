namespace UpToDo.Contracts.Subtasks.Requests;

/// <summary>
/// Запрос на обновление подзадачи.
/// </summary>
public sealed record UpdateSubtaskRequest(
    Guid Id,              // Идентификатор подзадачи
    string? Name,          // Название подзадачи
    bool IsCompleted      // Статус выполнения подзадачи
);