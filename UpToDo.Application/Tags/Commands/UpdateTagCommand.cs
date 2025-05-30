using MediatR;
using UpToDo.Contracts.Tags.Responses;

namespace UpToDo.Application.Tags.Commands;

public class UpdateTagCommand : IRequest<UpdateTagResponse>
{
    public Guid TagId { get; set; }
    public required string NewTagName { get; set; }
}