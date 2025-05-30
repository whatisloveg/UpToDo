using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.Tags.Queries;

public class GetAllUserTagsQueryHandler(ITagRepository repository) 
    : IRequestHandler<GetAllUserTagsQuery, List<Tag>>
{
    public async Task<List<Tag>> Handle(GetAllUserTagsQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetAllByUserIdAsync(request.UserId);
    }
}