using MediatR;
using UpToDo.Contracts.TasksLists.Responses;

namespace UpToDo.Application.TasksLists.Commands;

/// <summary>
/// Команда для создания списка задач.
/// </summary>
public class CreateTasksListCommand(string name, Guid userId) : IRequest<CreateTasksListResponse>
{
    /// <summary>
    /// Название списка задач
    /// </summary>
    public string Name { get; set; } = name; 
    
    /// <summary>
    /// Идентификатор пользователя
    /// </summary>
    public Guid UserId { get; set; } = userId;
}