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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}