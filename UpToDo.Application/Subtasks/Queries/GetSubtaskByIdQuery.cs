using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.Subtasks.Queries;

public class GetSubtaskByIdQuery : IRequest<Subtask?>
{
    public Guid Id { get; set; }
}