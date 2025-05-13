using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.TasksLists.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.TasksLists.Commands;

public class CreateTasksListCommandHandler(ITasksListRepository repository)
    : IRequestHandler<CreateTasksListCommand, CreateTasksListResponse>
{
    public async Task<CreateTasksListResponse> Handle(CreateTasksListCommand request, CancellationToken cancellationToken)
    {
        var tasksList = new TasksList
        {
            Name = request.Name,
            UserId = request.UserId
        };

        await repository.AddAsync(tasksList);
        return new CreateTasksListResponse(tasksList.Id); 
    }
}