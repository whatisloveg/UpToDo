using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

public class TagRepository(DataBaseContext context): ITagRepository
{
    public async Task AddAsync(Tag tag)
    {
        await context.Tags.AddAsync(tag);
        await context.SaveChangesAsync();
    }

    public async Task<Tag?> GetByIdAsync(Guid id)
    {
        return await context.Tags.FindAsync(id);
    }

    public async Task<List<Tag>> GetAllAsync()
    {
        return await context.Tags
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        context.Tags.Update(tag);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var tag = await context.Tags.FindAsync(id);
        if (tag != null)
        {
            context.Tags.Remove(tag);
            await context.SaveChangesAsync();
        }
    }
}