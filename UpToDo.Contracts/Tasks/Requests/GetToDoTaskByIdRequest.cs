namespace UpToDo.Contracts.Tasks.Requests;

/// <summary>   
/// Запрос на получение задачи по ID.
/// </summary>
public record GetToDoTaskByIdRequest(
    Guid Id  
);