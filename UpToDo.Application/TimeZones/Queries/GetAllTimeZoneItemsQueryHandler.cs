using MediatR;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.TimeZones.Responses;

namespace UpToDo.Application.TimeZones.Queries;

public class GetAllTimeZoneItemsQueryHandler(ITimeZoneItemRepository repository)
    : IRequestHandler<GetAllTimeZoneItemsQuery, List<TimeZoneItemResponse>>
{
    public async Task<List<TimeZoneItemResponse>> Handle(GetAllTimeZoneItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await repository.GetAllAsync();
        return items.Select(x => new TimeZoneItemResponse(
            x.Id,
            x.Name,
            x.DisplayName,
            x.UtcOffset
        )).ToList();
    }
}