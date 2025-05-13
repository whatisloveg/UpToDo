using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.TasksLists.Queries;

/// <summary>
/// Запрос на получение всех списков задач для пользователя.
/// </summary>
public class GetAllTasksListsByUserIdQuery(Guid userId) : IRequest<List<TasksList>>
{
    /// <summary>
    /// ID пользователя
    /// </summary>
    public Guid UserId { get; set; } = userId;
}