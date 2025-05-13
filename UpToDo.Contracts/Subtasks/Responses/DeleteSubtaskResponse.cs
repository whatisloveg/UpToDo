namespace UpToDo.Contracts.Subtasks.Responses;

/// <summary>
/// Ответ на удаление подзадачи.
/// </summary>
public sealed record DeleteSubtaskResponse(
    bool Success // Успешность выполнения операции
);