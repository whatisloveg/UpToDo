using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Application.Tasks.Commands;
using UpToDo.Contracts.Subtasks.Responses;
using UpToDo.Contracts.Tasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Subtasks.Commands;

public class CreateSubtaskCommandHandler(ISubtaskRepository repository) : IRequestHandler<CreateSubtaskCommand, CreateSubtaskResponse>
{
    public async Task<CreateSubtaskResponse> Handle(CreateSubtaskCommand request, CancellationToken cancellationToken)
    {
        var task = new Subtask()
        {
            Name = request.Name,
            ToDoTaskId = request.ToDoTaskId
        };

        await repository.AddAsync(task);
        return new CreateSubtaskResponse(task.Id);
    }
}