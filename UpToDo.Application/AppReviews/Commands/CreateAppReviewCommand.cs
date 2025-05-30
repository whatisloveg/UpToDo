using MediatR;
using UpToDo.Contracts.AppReviews.Responses;

namespace UpToDo.Application.AppReviews.Commands;

public class CreateAppReviewCommand: IRequest<CreateAppReviewResponse>
{
    public Guid UserId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}