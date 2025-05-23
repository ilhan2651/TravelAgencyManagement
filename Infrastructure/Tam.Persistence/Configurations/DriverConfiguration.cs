using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LicenseNumber).HasMaxLength(100);
            builder.Property(x => x.LicenseExpiryDate).IsRequired(false);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasOne(x => x.Supplier)
                   .WithMany(s => s.Drivers)
                   .HasForeignKey(x => x.SupplierId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(x => x.DriverLocations)
                   .WithOne(dl => dl.Driver)
                   .HasForeignKey(dl => dl.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DriverTransfers)
                   .WithOne(dt => dt.Driver)
                   .HasForeignKey(dt => dt.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TourDrivers)
                    .WithOne(td => td.Driver)
                     .HasForeignKey(td => td.DriverId)
                     .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
