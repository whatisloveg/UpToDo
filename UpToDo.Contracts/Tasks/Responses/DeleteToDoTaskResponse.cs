namespace UpToDo.Contracts.Tasks.Responses;

/// <summary>
/// Ответ на удаление задачи.
/// </summary>
public record DeleteToDoTaskResponse(
    bool Success // Успешность выполнения операции
);