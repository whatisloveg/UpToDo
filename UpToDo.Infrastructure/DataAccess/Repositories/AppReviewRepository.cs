using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

public class AppReviewRepository(DataBaseContext context) : IAppReviewRepository
{
    public async Task AddAsync(AppReview review, CancellationToken ct = default)
    {
        await context.AppReviews.AddAsync(review, ct);
        await context.SaveChangesAsync(ct);
    }
}