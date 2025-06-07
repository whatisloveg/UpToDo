namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>
/// Запрос на создание задачи.
/// </summary>
public record CreateToDoTaskRequest(
    string Name,           
    Guid TasksListId       
);