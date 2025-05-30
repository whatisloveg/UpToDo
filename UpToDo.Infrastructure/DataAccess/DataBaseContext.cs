using Microsoft.EntityFrameworkCore;
using UpToDo.Domain;
using UpToDo.Infrastructure.DataAccess.Configurations;

namespace UpToDo.Infrastructure.DataAccess;

/// <summary>
/// Класс конекста базы данных
/// </summary>
public class DataBaseContext(DbContextOptions<DataBaseContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<TasksList> TasksLists { get; set; }
    public DbSet<ToDoTask> ToDoTasks { get; set; }
    public DbSet<Subtask> Subtasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new TasksListConfiguration());
        modelBuilder.ApplyConfiguration(new ToDoTaskConfiguration());
        modelBuilder.ApplyConfiguration(new SubtaskConfiguration());
        modelBuilder.ApplyConfiguration(new TagConfiguration());
        modelBuilder.ApplyConfiguration(new ToDoTaskTagConfiguration());
        
    }
}