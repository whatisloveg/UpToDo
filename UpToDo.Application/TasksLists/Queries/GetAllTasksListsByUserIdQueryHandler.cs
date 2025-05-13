using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.TasksLists.Queries;

public class GetAllTasksListsByUserIdQueryHandler(ITasksListRepository repository)
    : IRequestHandler<GetAllTasksListsByUserIdQuery, List<TasksList>>
{
    public async Task<List<TasksList>> Handle(GetAllTasksListsByUserIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllByUserIdAsync(request.UserId);
    }
}