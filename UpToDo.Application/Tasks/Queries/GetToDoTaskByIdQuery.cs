using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Queries;

public class GetToDoTaskByIdQuery: IRequest<ToDoTask?>
{
    public Guid Id { get; set; }
}