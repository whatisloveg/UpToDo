using MediatR;
using UpToDo.Contracts.Subtasks.Responses;

namespace UpToDo.Application.Subtasks.Commands;

public class CreateSubtaskCommand: IRequest<CreateSubtaskResponse>
{
    public string? Name { get; set; }
    public Guid ToDoTaskId { get; set; }
}