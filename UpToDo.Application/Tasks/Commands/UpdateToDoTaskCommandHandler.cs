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

        task.Name = request.Name;
        task.Description = request.Description;
        task.EstimatedTime = request.EstimatedTime;
        task.IsCompleted = request.IsCompleted;

        await repository.UpdateAsync(task);
        return new UpdateToDoTaskResponse(true); 
    }
}