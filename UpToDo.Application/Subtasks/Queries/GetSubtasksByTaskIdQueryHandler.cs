using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.Subtasks.Queries;

public class GetSubtasksByTaskIdQueryHandler(ISubtaskRepository repository)
    : IRequestHandler<GetSubtasksByTaskIdQuery, List<Subtask>>
{
    public async Task<List<Subtask>> Handle(GetSubtasksByTaskIdQuery request, CancellationToken cancellationToken)
    {
        var subtasks = await repository.GetByTodoTaskAsync(request.TaskId);

        return subtasks;
    }
}