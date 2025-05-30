using MediatR;
using UpToDo.Contracts.Tags.Responses;

namespace UpToDo.Application.Tags.Commands;

public class CreateTagCommand : IRequest<CreateTagResponse>
{
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
}