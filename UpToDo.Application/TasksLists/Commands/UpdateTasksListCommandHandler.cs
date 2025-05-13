using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.TasksLists.Responses;

namespace UpToDo.Application.TasksLists.Commands;

public class UpdateTasksListCommandHandler(ITasksListRepository repository)
    : IRequestHandler<UpdateTasksListCommand, UpdateTasksListResponse>
{
    public async Task<UpdateTasksListResponse> Handle(UpdateTasksListCommand request, CancellationToken cancellationToken)
    {
        var tasksList = await repository.GetByIdAsync(request.Id);
        if (tasksList == null)
        {
            throw new TasksListNotFoundException();
        }

        tasksList.Name = request.Name;

        await repository.UpdateAsync(tasksList);
        return new UpdateTasksListResponse(true); 
    }
}