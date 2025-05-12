using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

public class TasksListConfiguration: IEntityTypeConfiguration<TasksList>
{
    public void Configure(EntityTypeBuilder<TasksList> builder)
    {
        builder.HasKey(tl => tl.Id);

        builder.Property(tl => tl.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(tl => tl.CreatedAt)
            .IsRequired();

        builder.HasMany(tl => tl.Tasks)
            .WithOne(t => t.TasksList)
            .HasForeignKey(t => t.TasksListId)
            .OnDelete(DeleteBehavior.Cascade);
        
    }
}