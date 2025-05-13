namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>
/// Запрос на создание задачи.
/// </summary>
public record CreateToDoTaskRequest(
    string Name,           // Название задачи
    string Description,    // Описание задачи
    decimal? EstimatedTime, // Время, выделенное на задачу
    Guid TasksListId       // Список задач, к которому относится задача
);