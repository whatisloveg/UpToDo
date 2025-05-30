namespace UpToDo.Contracts.TimeZones.Responses;

public record TimeZoneItemResponse(
    int Id,
    string Name,
    string DisplayName,
    int UtcOffset
);