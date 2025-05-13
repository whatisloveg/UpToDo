namespace UpToDo.Contracts.TasksLists.Responses;

/// <summary>
/// Ответ на обновление списка задач.
/// </summary>
public record UpdateTasksListResponse(
    bool Success  // Успешность выполнения операции
);