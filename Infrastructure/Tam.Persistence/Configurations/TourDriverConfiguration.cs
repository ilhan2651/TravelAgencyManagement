using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Persistence.Configurations
{
    public class TourDriverConfiguration : IEntityTypeConfiguration<TourDriver>
    {
        public void Configure(EntityTypeBuilder<TourDriver> builder)
        {
            builder.HasKey(x => new { x.TourId, x.DriverId });

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.TourDrivers)
                   .HasForeignKey(x => x.TourId);

            builder.HasOne(x => x.Driver)
                   .WithMany(d => d.TourDrivers)
                   .HasForeignKey(x => x.DriverId);
        }
    }
    
}
