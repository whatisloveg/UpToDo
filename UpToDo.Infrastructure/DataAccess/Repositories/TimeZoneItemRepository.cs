using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

public class TimeZoneItemRepository(DataBaseContext context) : ITimeZoneItemRepository
{
    /// <summary>
    /// Получить все таймзоны.
    /// </summary>
    public async Task<List<TimeZoneItem>> GetAllAsync()
    {
        return await context.TimeZoneItems
            .AsNoTracking()
            .ToListAsync();
    }
}