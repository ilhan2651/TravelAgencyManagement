using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tam.Domain.Entities;

public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
{
    public void Configure(EntityTypeBuilder<Discount> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(x => x.Type)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(x => x.Value)
               .HasPrecision(10, 2)
               .IsRequired();

        builder.Property(x => x.MinAmount)
               .HasPrecision(10, 2);

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);

        builder.Property(x => x.StartDate)
               .IsRequired();

        builder.Property(x => x.EndDate)
               .IsRequired(false);

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("TIMEZONE('UTC', now())");
        builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);

        builder.HasMany(d => d.TourReservations)
               .WithOne(r => r.Discount)
               .HasForeignKey(r => r.DiscountId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(d => d.TransferReservations)
               .WithOne(r => r.Discount)
               .HasForeignKey(r => r.DiscountId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(d => d.HotelReservations)
               .WithOne(r => r.Discount)
               .HasForeignKey(r => r.DiscountId)
               .OnDelete(DeleteBehavior.SetNull);
    }
}
