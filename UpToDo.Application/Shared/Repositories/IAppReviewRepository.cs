using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

public interface IAppReviewRepository
{
    Task AddAsync(AppReview review, CancellationToken ct = default);
}