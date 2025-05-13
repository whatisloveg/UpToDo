using MediatR;
using UpToDo.Contracts.TasksLists.Responses;

namespace UpToDo.Application.TasksLists.Commands;

/// <summary>
/// Команда для обновления списка задач.
/// </summary>
public class UpdateTasksListCommand(Guid id, string name) : IRequest<UpdateTasksListResponse>
{
    /// <summary>
    /// Идентификатор списка задач
    /// </summary>
    public Guid Id { get; set; } = id; 
    
    /// <summary>
    /// Название списка задач
    /// </summary>
    public string Name { get; set; } = name; 
}