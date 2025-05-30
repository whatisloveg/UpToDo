using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

/// <summary>
/// Репозиторий для связи задач и тегов.
/// </summary>
public class ToDoTaskTagRepository(DataBaseContext context) : IToDoTaskTagRepository
{
    public async Task AddAsync(ToDoTaskTag toDoTaskTag)
    {
        await context.ToDoTaskTags.AddAsync(toDoTaskTag);
        await context.SaveChangesAsync();
    }

    public async Task<ToDoTaskTag?> GetByIdsAsync(Guid taskId, Guid tagId)
    {
        return await context.ToDoTaskTags
            .Include(x => x.Tag)
            .FirstOrDefaultAsync(x => x.ToDoTaskId == taskId && x.TagId == tagId);
    }

    public async Task<List<ToDoTaskTag>> GetByTaskIdAsync(Guid taskId)
    {
        return await context.ToDoTaskTags
            .Where(x => x.ToDoTaskId == taskId)
            .Include(x => x.Tag)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid taskId, Guid tagId)
    {
        var entity = await context.ToDoTaskTags
            .FirstOrDefaultAsync(x => x.ToDoTaskId == taskId && x.TagId == tagId);
        if (entity != null)
        {
            context.ToDoTaskTags.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}