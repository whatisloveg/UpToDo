using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class UpdateToDoTaskCommandHandler(IToDoTaskRepository repository) : IRequestHandler<UpdateToDoTaskCommand, UpdateToDoTaskResponse>
{
    public async Task<UpdateToDoTaskResponse> Handle(UpdateToDoTaskCommand request, CancellationToken cancellationToken)
    {
        var task = await repository.GetByIdAsync(request.Id);
        if (task == null)
        {
            throw new TaskNotFoundException();
        }

        if (request.Name != null)
        {
            task.Name = request.Name;
        }

        if (request.Description != null)
        {
            task.Description = request.Description;
        }

        if (request.EstimatedTime != null)
        {
            task.EstimatedTime = request.EstimatedTime;
        }

        if (request.IsCompleted)
        {
            task.IsCompleted = request.IsCompleted;
            task.CompletedAt = DateTime.UtcNow;
        }
        
        await repository.UpdateAsync(task);
        return new UpdateToDoTaskResponse(true); 
    }
}