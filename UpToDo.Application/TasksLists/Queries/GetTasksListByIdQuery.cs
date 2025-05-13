using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.TasksLists.Queries;

/// <summary>
/// Запрос на получение списка задач по ID.
/// </summary>
public class GetTasksListByIdQuery(Guid id) : IRequest<TasksList?>
{
    /// <summary>
    /// Id списка задач
    /// </summary>
    public Guid Id { get; set; } = id;
}