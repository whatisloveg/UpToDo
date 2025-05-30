using MediatR;
using UpToDo.Contracts.Tags.Responses;

namespace UpToDo.Application.Tags.Commands;

public class DeleteTagCommand : IRequest<DeleteTagResponse>
{
    public Guid TagId { get; set; }
}