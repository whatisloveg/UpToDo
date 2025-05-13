namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>
/// Запрос на удаление задачи.
/// </summary>
public sealed record DeleteToDoTaskRequest(
    Guid Id // Идентификатор задачи
);