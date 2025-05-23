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
    public class DriverLocationConfiguration : IEntityTypeConfiguration<DriverLocation>
    {
        public void Configure(EntityTypeBuilder<DriverLocation> builder)
        {
            builder.HasKey(x => new { x.DriverId, x.LocationId });

            builder.HasOne(x => x.Driver)
                   .WithMany(d => d.DriverLocations)
                   .HasForeignKey(x => x.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Location)
                   .WithMany(l => l.DriverLocations)
                   .HasForeignKey(x => x.LocationId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Note).HasMaxLength(300);
        }
    }

}
