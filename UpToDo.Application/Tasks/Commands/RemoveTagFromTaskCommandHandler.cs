using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class RemoveTagFromTaskCommandHandler(IToDoTaskTagRepository repository)
    : IRequestHandler<RemoveTagFromTaskCommand, AddTagToTaskToTagResponse>
{
    public async Task<AddTagToTaskToTagResponse> Handle(RemoveTagFromTaskCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.TaskId, request.TagId);
        return new AddTagToTaskToTagResponse(true);
    }
}