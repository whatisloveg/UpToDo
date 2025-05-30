using MediatR;
using UpToDo.Contracts.Tasks.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Tasks.Queries;

public class GetTaskTagsQuery : IRequest<List<GetTaskTagResponse>>
{
    public Guid TaskId { get; set; }
}