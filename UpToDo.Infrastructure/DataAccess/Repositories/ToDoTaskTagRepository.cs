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

    public async Task<ToDoTaskTag?> GetByIdsAsync(Guid toDoTaskId, Guid tagId)
    {
        return await context.ToDoTaskTags
            .FirstOrDefaultAsync(x => x.ToDoTaskId == toDoTaskId && x.TagId == tagId);
    }

    public async Task<List<ToDoTaskTag>> GetByTaskIdAsync(Guid toDoTaskId)
    {
        return await context.ToDoTaskTags
            .Where(x => x.ToDoTaskId == toDoTaskId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<ToDoTaskTag>> GetByTagIdAsync(Guid tagId)
    {
        return await context.ToDoTaskTags
            .Where(x => x.TagId == tagId)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid toDoTaskId, Guid tagId)
    {
        var entity = await context.ToDoTaskTags
            .FirstOrDefaultAsync(x => x.ToDoTaskId == toDoTaskId && x.TagId == tagId);
        if (entity != null)
        {
            context.ToDoTaskTags.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}