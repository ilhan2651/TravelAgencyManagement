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
    public class TourRegionConfiguration : IEntityTypeConfiguration<TourRegion>
    {
        public void Configure(EntityTypeBuilder<TourRegion> builder)
        {
            builder.HasKey(x => new { x.TourId, x.RegionId });

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.TourRegions)
                   .HasForeignKey(x => x.TourId);

            builder.HasOne(x => x.Region)
                   .WithMany(r => r.TourRegions)
                   .HasForeignKey(x => x.RegionId);
        }
    }

}
