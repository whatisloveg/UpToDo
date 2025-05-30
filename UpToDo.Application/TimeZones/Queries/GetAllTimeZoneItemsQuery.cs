using MediatR;
using UpToDo.Contracts.TimeZones.Responses;

namespace UpToDo.Application.TimeZones.Queries;

public class GetAllTimeZoneItemsQuery : IRequest<List<TimeZoneItemResponse>>
{
}