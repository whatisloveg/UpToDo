using Microsoft.EntityFrameworkCore;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Repositories;

public class TasksListRepository(DataBaseContext context) : ITasksListRepository
{ 
    public async Task AddAsync(TasksList tasksList)
    {
        await context.TasksLists.AddAsync(tasksList);
        await context.SaveChangesAsync();
    }

    public async Task<TasksList?> GetByIdAsync(Guid id)
    {
        return await context.TasksLists.FindAsync(id);
    }

    public async Task<List<TasksList>> GetAllByUserIdAsync(Guid userId)
    {
        return await context.TasksLists
            .Where(tl => tl.UserId == userId)
            .ToListAsync();
    }

    public async Task UpdateAsync(TasksList tasksList)
    {
        context.TasksLists.Update(tasksList);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var tasksList = await context.TasksLists.FindAsync(id);
        if (tasksList != null)
        {
            context.TasksLists.Remove(tasksList);
            await context.SaveChangesAsync();
        }
    }
}