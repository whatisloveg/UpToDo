using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tags.Responses;

namespace UpToDo.Application.Tags.Commands;

public class DeleteTagCommandHandler(ITagRepository repository) 
    : IRequestHandler<DeleteTagCommand, DeleteTagResponse>
{
    public async Task<DeleteTagResponse> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        await repository.DeleteAsync(request.TagId);
        return new DeleteTagResponse(true);
    }
}