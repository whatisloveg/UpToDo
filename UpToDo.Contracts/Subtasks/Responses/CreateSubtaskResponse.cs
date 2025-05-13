namespace UpToDo.Contracts.Subtasks.Responses;

/// <summary>
/// Ответ на добавление подзадачи.
/// </summary>
public record CreateSubtaskResponse(
    Guid SubtaskId // Идентификатор подзадачи
);