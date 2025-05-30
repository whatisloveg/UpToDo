using MediatR;
using UpToDo.Domain;

namespace UpToDo.Application.Tags.Queries;

public class GetTagByIdQuery : IRequest<Tag?>
{
    public Guid TagId { get; set; }
}