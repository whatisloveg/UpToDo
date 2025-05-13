using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Queries;

public class GetAllToDoTasksQueryHandler(IToDoTaskRepository repository)
    : IRequestHandler<GetAllToDoTasksQuery, List<ToDoTask>>
{
    public async Task<List<ToDoTask>> Handle(GetAllToDoTasksQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllByTasksListIdAsync(request.TasksListId);
    }
}