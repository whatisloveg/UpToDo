using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class DeleteToDoTaskCommandHandler(IToDoTaskRepository repository) : IRequestHandler<DeleteToDoTaskCommand, DeleteToDoTaskResponse>
{
    public async Task<DeleteToDoTaskResponse> Handle(DeleteToDoTaskCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return new DeleteToDoTaskResponse(true);
    }
}