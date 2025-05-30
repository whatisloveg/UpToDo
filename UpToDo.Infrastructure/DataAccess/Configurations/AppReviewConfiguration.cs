using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UpToDo.Domain;

namespace UpToDo.Infrastructure.DataAccess.Configurations;


/// <summary>
/// Конфигурация для таблицы отзывов о приложении.
/// </summary>
public class AppReviewConfiguration: IEntityTypeConfiguration<AppReview>
{
    public void Configure(EntityTypeBuilder<AppReview> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Rating)
            .IsRequired()
            .HasDefaultValue(1);
        
        builder.HasCheckConstraint("CK_AppReview_Rating_Range", "\"Rating\" >= 1 AND \"Rating\" <= 10");

        builder.Property(x => x.Comment)
            .HasMaxLength(4000);

        builder.HasOne(x => x.User)
            .WithMany(u => u.AppReviews)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}