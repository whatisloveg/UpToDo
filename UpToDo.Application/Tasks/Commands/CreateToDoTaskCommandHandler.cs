using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tasks.Requests;
using UpToDo.Contracts.Tasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Commands;

public class CreateToDoTaskCommandHandler(IToDoTaskRepository repository)  : IRequestHandler<CreateToDoTaskCommand, CreateToDoTaskResponse>
{
    public async Task<CreateToDoTaskResponse> Handle(CreateToDoTaskCommand request, CancellationToken cancellationToken)
    {
        var task = new ToDoTask
        {
            Name = request.Name,
            TasksListId = request.TasksListId
        };

        await repository.AddAsync(task);
        return new CreateToDoTaskResponse(task.Id);
    }
}