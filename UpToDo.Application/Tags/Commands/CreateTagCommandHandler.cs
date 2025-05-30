using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Tags.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.Tags.Commands;

public class CreateTagCommandHandler(ITagRepository repository) 
    : IRequestHandler<CreateTagCommand, CreateTagResponse>
{
    public async Task<CreateTagResponse> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = new Tag
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Name = request.Name
        };

        await repository.AddAsync(tag);
        return new CreateTagResponse(tag.Id);
    }
}