using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.Subtasks.Queries;

public class GetSubtasksByTaskIdQuery : IRequest<List<Subtask>>
{
    public Guid TaskId { get; set; }
}