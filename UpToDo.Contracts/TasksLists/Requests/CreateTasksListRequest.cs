namespace UpToDo.Contracts.TasksLists.Requests;

/// <summary>
/// Запрос для создания списка задач.
/// </summary>
public record CreateTasksListRequest(
    string Name, // Название списка задач
    Guid UserId  // Идентификатор пользователя
);