using MediatR;
using UpToDo.Application.Shared.Exceptions;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Application.Subtasks.Commands;
using UpToDo.Contracts.Subtasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Subtasks.Queries;

public class GetSubtaskByIdQueryHandler(ISubtaskRepository repository) : IRequestHandler<GetSubtaskByIdQuery, Subtask?>
{
    public async Task<Subtask?> Handle(GetSubtaskByIdQuery request, CancellationToken cancellationToken)
    {
        var subtask = await repository.GetByIdAsync(request.Id);
        if (subtask == null)
        {
            throw new TaskNotFoundException(); 
        }
        
        return subtask;
    }
}