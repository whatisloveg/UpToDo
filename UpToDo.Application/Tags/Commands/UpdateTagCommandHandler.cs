using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tags.Responses;

namespace UpToDo.Application.Tags.Commands;

public class UpdateTagCommandHandler(ITagRepository repository)
    : IRequestHandler<UpdateTagCommand, UpdateTagResponse>
{
    public async Task<UpdateTagResponse> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await repository.GetByIdAsync(request.TagId);
        if (tag == null)
            return new UpdateTagResponse(false);

        tag.Name = request.NewTagName;
        await repository.UpdateAsync(tag);
        return new UpdateTagResponse(true);
    }
}
