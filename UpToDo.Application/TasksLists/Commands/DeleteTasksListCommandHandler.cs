using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.TasksLists.Responses;

namespace UpToDo.Application.TasksLists.Commands;

public class DeleteTasksListCommandHandler(ITasksListRepository repository)
    : IRequestHandler<DeleteTasksListCommand, DeleteTasksListResponse>
{
    public async Task<DeleteTasksListResponse> Handle(DeleteTasksListCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.Id);
        return new DeleteTasksListResponse(true);
    }
}