using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

public class UserSettingsConfiguration : IEntityTypeConfiguration<UserSettings>
{
    public void Configure(EntityTypeBuilder<UserSettings> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.User)
            .WithOne(u => u.Settings)
            .HasForeignKey<UserSettings>(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.TimeZone)
            .WithMany()
            .HasForeignKey(x => x.TimeZoneItemId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Property(x => x.CompanyNotificationsEnabled)
            .IsRequired();
    }
}