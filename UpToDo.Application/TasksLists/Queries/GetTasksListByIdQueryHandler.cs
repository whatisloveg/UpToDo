using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.TasksLists.Queries;

public class GetTasksListByIdQueryHandler(ITasksListRepository repository)
    : IRequestHandler<GetTasksListByIdQuery, TasksList?>
{
    public async Task<TasksList?> Handle(GetTasksListByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}