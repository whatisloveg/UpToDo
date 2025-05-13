namespace UpToDo.Contracts.Subtasks.Requests;

/// <summary>
/// Запрос на удаление подзадачи.
/// </summary>
public sealed record DeleteSubtaskRequest(
    Guid Id // Идентификатор подзадачи
);