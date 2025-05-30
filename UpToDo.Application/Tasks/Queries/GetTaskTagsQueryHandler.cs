using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Queries;

public class GetTaskTagsQueryHandler(IToDoTaskTagRepository repository)
    : IRequestHandler<GetTaskTagsQuery, List<GetTaskTagResponse>>
{
    public async Task<List<GetTaskTagResponse>> Handle(GetTaskTagsQuery request, CancellationToken cancellationToken)
    {
        var entities = await repository.GetByTaskIdAsync(request.TaskId);
        
        var response = entities
            .Where(x => x.Tag != null)
            .Select(x => new GetTaskTagResponse(x.TagId, x.Tag!.Name))
            .ToList();

        return response;
    }
}