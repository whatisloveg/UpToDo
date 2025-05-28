using MediatR;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class CreateToDoTaskCommand: IRequest<CreateToDoTaskResponse>
{
    public string? Name { get; set; }
    public Guid TasksListId { get; set; }
}