using MediatR;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class DeleteToDoTaskCommand : IRequest<DeleteToDoTaskResponse>
{
    public Guid Id { get; set; }
}