using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Commands;

public class AddTagToTaskToTagCommandHandler(IToDoTaskTagRepository repository)
    : IRequestHandler<AddTagToTaskToTagCommand, AddTagToTaskToTagResponse>
{
    public async Task<AddTagToTaskToTagResponse> Handle(AddTagToTaskToTagCommand request, CancellationToken cancellationToken)
    {
        // Проверяем, что такой связи ещё нет (чтобы не было дубля)
        var existing = await repository.GetByIdsAsync(request.TaskId, request.TagId);
        if (existing != null)
            return new AddTagToTaskToTagResponse(false);

        var entity = new ToDoTaskTag
        {
            ToDoTaskId = request.TaskId,
            TagId = request.TagId
        };

        await repository.AddAsync(entity);
        return new AddTagToTaskToTagResponse(true);
    }
}