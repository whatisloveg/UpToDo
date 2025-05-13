using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Queries;

public class GetAllToDoTasksQuery : IRequest<List<ToDoTask>>
{
    public Guid TasksListId { get; set; }
}