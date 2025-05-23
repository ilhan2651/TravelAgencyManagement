using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Tam.Domain.Entities;

public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Type).IsRequired().HasMaxLength(100);
        builder.Property(x => x.PlateNumber).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Brand).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Model).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Color).HasMaxLength(50);
        builder.Property(x => x.Capacity).IsRequired();

        builder.Property(x => x.CreatedAt)
               .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
        builder.Property(x => x.DeletedAt).IsRequired(false);

        builder.HasOne(v => v.Supplier)
               .WithMany(s => s.Vehicles)
               .HasForeignKey(v => v.SupplierId)
               .OnDelete(DeleteBehavior.SetNull);

        builder.HasMany(v => v.TourVehicles)
               .WithOne(tv => tv.Vehicle)
               .HasForeignKey(tv => tv.VehicleId)
               .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(v => v.TransferVehicles)
            .WithOne(tv => tv.Vehicle)
                .HasForeignKey(tv => tv.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
