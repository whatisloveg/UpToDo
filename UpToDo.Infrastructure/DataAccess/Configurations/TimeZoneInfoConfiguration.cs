using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

public class TimeZoneInfoConfiguration  : IEntityTypeConfiguration<TimeZoneItem>
{
    public void Configure(EntityTypeBuilder<TimeZoneItem> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);
        
        builder.Property(x => x.DisplayName)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(x => x.UtcOffset)
            .IsRequired();
    }
}