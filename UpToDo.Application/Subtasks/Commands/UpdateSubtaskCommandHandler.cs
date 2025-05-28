using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Subtasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Subtasks.Commands;

public class UpdateSubtaskCommandHandler(ISubtaskRepository repository) : IRequestHandler<UpdateSubtaskCommand, UpdateSubtaskResponse>
{
    public async Task<UpdateSubtaskResponse> Handle(UpdateSubtaskCommand request, CancellationToken cancellationToken)
    {
        var subtask = await repository.GetByIdAsync(request.Id);
        if (subtask == null)
        {
            throw new TaskNotFoundException();  // Можно сделать своё исключение для подзадачи
        }
        
        if (request.Name != null)
        {
            subtask.Name = request.Name;
        }
        
        if (request.IsCompleted)
        {
            subtask.IsCompleted = request.IsCompleted;
            subtask.CompletedAt = DateTime.UtcNow;
        }
        

        await repository.UpdateAsync(subtask);
        return new UpdateSubtaskResponse(true);
    }
}