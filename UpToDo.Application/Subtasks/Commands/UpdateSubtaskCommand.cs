using MediatR;
using UpToDo.Contracts.Subtasks.Responses;

namespace UpToDo.Application.Subtasks.Commands;

public class UpdateSubtaskCommand: IRequest<UpdateSubtaskResponse>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public bool IsCompleted { get; set; }
}