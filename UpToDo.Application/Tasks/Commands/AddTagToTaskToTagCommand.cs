using MediatR;
using UpToDo.Contracts.Tasks.Responses;

namespace UpToDo.Application.Tasks.Commands;

public class AddTagToTaskToTagCommand : IRequest<AddTagToTaskToTagResponse>
{
    public Guid TaskId { get; set; }
    public Guid TagId { get; set; }
}