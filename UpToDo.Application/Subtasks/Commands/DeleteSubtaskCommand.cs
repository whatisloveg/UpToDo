using MediatR;

namespace UpToDo.Application.Subtasks.Commands;

public class DeleteSubtaskCommand: IRequest
{
    public Guid Id { get; set; }
}