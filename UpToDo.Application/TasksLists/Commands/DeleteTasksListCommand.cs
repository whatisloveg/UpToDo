using MediatR;
using UpToDo.Contracts.TasksLists.Responses;

namespace UpToDo.Application.TasksLists.Commands;

/// <summary>
/// Команда для удаления списка задач.
/// </summary>
public class DeleteTasksListCommand(Guid id) : IRequest<DeleteTasksListResponse>
{
    /// <summary>
    /// Идентификатор списка задач
    /// </summary>
    public Guid Id { get; set; } = id; 
}