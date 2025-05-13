namespace UpToDo.Contracts.Tasks.Responses;

/// <summary>
/// Ответ на создание задачи.
/// </summary>
public record CreateToDoTaskResponse(
    Guid TaskId  // Идентификатор созданной задачи
);