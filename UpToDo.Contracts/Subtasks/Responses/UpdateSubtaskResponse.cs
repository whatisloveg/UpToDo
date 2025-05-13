namespace UpToDo.Contracts.Subtasks.Responses;

/// <summary>
/// Ответ на обновление подзадачи.
/// </summary>
public sealed record UpdateSubtaskResponse(
    bool Success // Успешность выполнения операции
);