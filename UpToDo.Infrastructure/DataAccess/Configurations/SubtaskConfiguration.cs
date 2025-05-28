using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

public class SubtaskConfiguration: IEntityTypeConfiguration<Subtask>
{
    public void Configure(EntityTypeBuilder<Subtask> builder)
    {

        builder.HasKey(st => st.Id);

        builder.Property(st => st.Name)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(st => st.IsCompleted)
            .HasDefaultValue(false);
        
        builder.Property(st => st.CreatedAt)
            .IsRequired();

        builder.Property(st => st.CompletedAt)
            .IsRequired(false);

        builder.HasOne(st => st.ToDoTask)
            .WithMany(t => t.Subtasks)
            .HasForeignKey(st => st.ToDoTaskId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}