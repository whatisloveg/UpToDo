using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

public class ToDoTaskTagConfiguration: IEntityTypeConfiguration<ToDoTaskTag>
{
    public void Configure(EntityTypeBuilder<ToDoTaskTag> builder)
    {
        builder.HasKey(x => new { x.ToDoTaskId, x.TagId });

        builder.HasOne(x => x.ToDoTask)
            .WithMany(t => t.ToDoTaskTags)
            .HasForeignKey(x => x.ToDoTaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Tag)
            .WithMany(t => t.ToDoTaskTags)
            .HasForeignKey(x => x.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}