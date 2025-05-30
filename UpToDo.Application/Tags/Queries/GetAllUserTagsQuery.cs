using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.Tags.Queries;

public class GetAllUserTagsQuery : IRequest<List<Tag>>
{
    public Guid UserId { get; set; }
}