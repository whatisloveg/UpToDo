using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Application.Tags.Queries;

public class GetTagByIdQueryHandler(ITagRepository repository) 
    : IRequestHandler<GetTagByIdQuery, Tag?>
{
    public async Task<Tag?> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.TagId);
    }
}