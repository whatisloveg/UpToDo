using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

/// <summary>
/// Репозиторий для работы с задачами.
/// </summary>
public class ToDoTaskRepository(DataBaseContext context) : IToDoTaskRepository
{
    public async Task AddAsync(ToDoTask task)
    {
        await context.ToDoTasks.AddAsync(task);
        await context.SaveChangesAsync();
    }

    public async Task<ToDoTask?> GetByIdAsync(Guid id)
    {
        return await context.ToDoTasks.FindAsync(id);
    }

    public async Task<List<ToDoTask>> GetAllByTasksListIdAsync(Guid tasksListId)
    {
        return await context.ToDoTasks
            .Where(t => t.TasksListId == tasksListId)
            .ToListAsync();
    }

    public async Task UpdateAsync(ToDoTask task)
    {
        context.ToDoTasks.Update(task);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var task = await context.ToDoTasks.FindAsync(id);
        if (task != null)
        {
            context.ToDoTasks.Remove(task);
            await context.SaveChangesAsync();
        }
    }
}