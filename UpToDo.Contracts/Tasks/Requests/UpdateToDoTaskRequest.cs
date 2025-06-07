using System.ComponentModel.DataAnnotations;
using UpToDo.Domain.Enums;

namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>
/// Запрос на обновление задачи.
/// </summary>
public record UpdateToDoTaskRequest(
    Guid Id,  
    string? Name,  
    string? Description,
    decimal? EstimatedTime, 
    bool IsCompleted,
    TaskMatrixPriority? MatrixPriority
);