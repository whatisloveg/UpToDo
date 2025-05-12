using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;
using UpToDo.Domain.Enums;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

public class ToDoTaskConfiguration: IEntityTypeConfiguration<ToDoTask>
{
    public void Configure(EntityTypeBuilder<ToDoTask> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(t => t.MatrixPriority)
            .HasDefaultValue(TaskMatrixPriority.Uncategorized);

        builder.Property(t => t.EstimatedTime)
            .IsRequired(false);

        builder.Property(t => t.IsCompleted)
            .HasDefaultValue(false);

        builder.Property(t => t.CreatedAt)
            .IsRequired();

        builder.Property(t => t.CompletedAt)
            .IsRequired(false);

        builder.HasOne(t => t.TasksList)
            .WithMany(tl => tl.Tasks)
            .HasForeignKey(t => t.TasksListId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(t => t.Subtasks)
            .WithOne(st => st.ToDoTask)
            .HasForeignKey(st => st.ToDoTaskId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}