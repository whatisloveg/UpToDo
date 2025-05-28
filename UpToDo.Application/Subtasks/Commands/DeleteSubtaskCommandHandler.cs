using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Subtasks.Responses;

namespace UpToDo.Application.Subtasks.Commands;

public class DeleteSubtaskCommandHandler(ISubtaskRepository repository) : IRequestHandler<DeleteSubtaskCommand, DeleteSubtaskResponse>
{
    public async Task<DeleteSubtaskResponse> Handle(DeleteSubtaskCommand request, CancellationToken cancellationToken)
    {
        var subtask = await repository.GetByIdAsync(request.Id);
        if (subtask == null)
        {
            throw new TaskNotFoundException();  
        }
        
        await repository.DeleteAsync(subtask.Id);
        return new DeleteSubtaskResponse(true);
    }
}