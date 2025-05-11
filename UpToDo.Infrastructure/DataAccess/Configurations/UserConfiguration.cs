using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;

/// <summary>
/// EF конфигурация сущности пользователя.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> cfg)
    {
        cfg.HasKey(u => u.Id);

        cfg.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(255);

        cfg.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        cfg.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(255);
    }
}