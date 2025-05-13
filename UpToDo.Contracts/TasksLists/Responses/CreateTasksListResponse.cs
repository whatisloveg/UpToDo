namespace UpToDo.Contracts.TasksLists.Responses;

/// <summary>
/// Ответ на создание списка задач.
/// </summary>
public record CreateTasksListResponse(
    Guid TasksListId   // Идентификатор созданного списка задач
);