namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>
/// Запрос на создание задачи.
/// </summary>
public record CreateToDoTaskRequest(
    string Name,           // Название задачи
    Guid TasksListId       // Список задач, к которому относится задача
);