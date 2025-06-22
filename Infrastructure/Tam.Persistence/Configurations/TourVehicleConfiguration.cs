using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Persistence.Configurations
{
    public class TourVehicleConfiguration : IEntityTypeConfiguration<TourVehicle>
    {
        public void Configure(EntityTypeBuilder<TourVehicle> builder)
        {
            builder.HasKey(x => new { x.TourId, x.VehicleId });

            builder.Property(x => x.Note)
                   .HasMaxLength(300);

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.TourVehicles)
                   .HasForeignKey(x => x.TourId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Vehicle)
                   .WithMany(v => v.TourVehicles)
                   .HasForeignKey(x => x.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
