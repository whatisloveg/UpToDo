namespace UpToDo.Contracts.TasksLists.Requests;

/// <summary>
/// Запрос на удаление списка задач.
/// </summary>
public record DeleteTasksListRequest(
    Guid Id  // Идентификатор списка задач
);