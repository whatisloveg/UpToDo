using MediatR;
using UpToDo.Contracts.Subtasks.Responses;

namespace UpToDo.Application.Subtasks.Commands;

public class DeleteSubtaskCommand: IRequest<DeleteSubtaskResponse>
{
    public Guid Id { get; set; }
}