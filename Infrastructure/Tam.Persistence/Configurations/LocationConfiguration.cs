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
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Country).HasMaxLength(100);
            builder.Property(x => x.City).IsRequired().HasMaxLength(100);
            builder.Property(x => x.District).HasMaxLength(100);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasMany(x => x.Hotels)
                   .WithOne(h => h.Location)
                   .HasForeignKey(h => h.LocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.GuideLocations)
                   .WithOne(gl => gl.Location)
                   .HasForeignKey(gl => gl.LocationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DriverLocations)
                   .WithOne(dl => dl.Location)
                   .HasForeignKey(dl => dl.LocationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.StartTours)
                   .WithOne(t => t.StartLocation)
                   .HasForeignKey(t => t.StartLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EndTours)
                   .WithOne(t => t.EndLocation)
                   .HasForeignKey(t => t.EndLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StartTransfers)
                   .WithOne(t => t.StartLocation)
                   .HasForeignKey(t => t.StartLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EndTransfers)
                   .WithOne(t => t.EndLocation)
                   .HasForeignKey(t => t.EndLocationId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StartRoutes)
                .WithOne(r => r.StartLocation)
                     .HasForeignKey(r => r.StartLocationId)
                     .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.EndRoutes)
                .WithOne(r => r.EndLocation)
                     .HasForeignKey(r => r.EndLocationId)
                     .OnDelete(DeleteBehavior.Restrict);


        }
    }

}
