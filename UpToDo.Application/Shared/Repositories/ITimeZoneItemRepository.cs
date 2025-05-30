using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

public interface ITimeZoneItemRepository
{
    Task<List<TimeZoneItem>> GetAllAsync();
}