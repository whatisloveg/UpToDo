namespace UpToDo.Contracts.AppReviews.Requests;

public record CreateAppReviewRequest(
    Guid UserId,
    int Rating,
    string? Comment
);