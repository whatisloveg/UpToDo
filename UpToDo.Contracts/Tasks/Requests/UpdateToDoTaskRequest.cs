using System.ComponentModel.DataAnnotations;

namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>
/// Запрос на обновление задачи.
/// </summary>
public record UpdateToDoTaskRequest(
    Guid Id,  // Идентификатор задачи
    string? Name,  // Название задачи
    string? Description, // Описание задачи
    decimal? EstimatedTime, // Время, выделенное на задачу
    bool IsCompleted // Статус выполнения задачи
);