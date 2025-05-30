using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.AppReviews.Responses;
using UpToDo.Domain;

namespace UpToDo.Application.AppReviews.Commands;

public class CreateAppReviewCommandHandler(IAppReviewRepository repository)
    : IRequestHandler<CreateAppReviewCommand, CreateAppReviewResponse>
{
    public async Task<CreateAppReviewResponse> Handle(CreateAppReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new AppReview
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Rating = request.Rating,
            Comment = request.Comment
        };

        await repository.AddAsync(review, cancellationToken);
        return new CreateAppReviewResponse(review.Id);
    }
}