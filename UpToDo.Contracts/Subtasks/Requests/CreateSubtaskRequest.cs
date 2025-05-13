namespace UpToDo.Contracts.Subtasks.Requests;

/// <summary>
/// Запрос на добавление подзадачи.
/// </summary>
public record CreateSubtaskRequest(
    string Name, // Название подзадачи
    decimal? EstimatedTime, // Время, выделенное на подзадачу
    Guid ToDoTaskId // Задача, к которой относится подзадача
);