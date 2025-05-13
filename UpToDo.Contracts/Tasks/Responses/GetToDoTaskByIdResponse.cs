namespace UpToDo.Contracts.Tasks.Responses;

public sealed record GetToDoTaskByIdResponse(
    Guid Id, // Идентификатор задачи
    string Name, // Название задачи
    string Description, // Описание задачи
    decimal? EstimatedTime, // Время, выделенное на задачу
    bool IsCompleted, // Статус выполнения задачи
    DateTime CreatedAt, // Дата создания задачи
    DateTime? CompletedAt // Дата завершения задачи
);