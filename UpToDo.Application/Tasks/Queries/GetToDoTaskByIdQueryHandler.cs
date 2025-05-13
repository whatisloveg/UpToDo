using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Queries;

public class GetToDoTaskByIdQueryHandler(IToDoTaskRepository repository)
    : IRequestHandler<GetToDoTaskByIdQuery, ToDoTask?>
{
    public async Task<ToDoTask?> Handle(GetToDoTaskByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}