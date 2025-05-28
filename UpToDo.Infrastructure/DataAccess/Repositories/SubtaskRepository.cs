using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;


/// <summary>
/// Репозиторий для работы с подзадачами.
/// </summary>
public class SubtaskRepository(DataBaseContext context) : ISubtaskRepository
{
    public async Task AddAsync(Subtask subtask)
    {
        await context.Subtasks.AddAsync(subtask);
        await context.SaveChangesAsync();
    }

    public async Task<Subtask?> GetByIdAsync(Guid id)
    {
        return await context.Subtasks.FindAsync(id);
    }
    
    public async Task<List<Subtask>> GetByTodoTaskAsync(Guid toDoTaskId)
    {
        return await context.Subtasks
            .AsNoTracking()
            .Where(st => st.ToDoTaskId == toDoTaskId)
            .ToListAsync();
    }

    public async Task UpdateAsync(Subtask subtask)
    {
        context.Subtasks.Update(subtask);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var subtask = await context.Subtasks.FindAsync(id);
        if (subtask != null)
        {
            context.Subtasks.Remove(subtask);
            await context.SaveChangesAsync();
        }
    }
}