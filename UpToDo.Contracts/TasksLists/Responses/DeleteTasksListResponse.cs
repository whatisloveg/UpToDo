namespace UpToDo.Contracts.TasksLists.Responses;

/// <summary>
/// Ответ на удаление списка задач.
/// </summary>
public record DeleteTasksListResponse(
    bool Success // Успешность выполнения операции
);