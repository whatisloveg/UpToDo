namespace UpToDo.Contracts.TasksLists.Requests;

/// <summary>
/// Запрос на обновление списка задач.
/// </summary>
public record UpdateTasksListRequest(
    Guid Id, // Идентификатор списка задач
    string Name  // Новое название списка задач
);