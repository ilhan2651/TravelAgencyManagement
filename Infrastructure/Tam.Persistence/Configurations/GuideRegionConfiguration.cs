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
    public class GuideRegionConfiguration : IEntityTypeConfiguration<GuideRegion>
    {
        public void Configure(EntityTypeBuilder<GuideRegion> builder)
        {
            builder.HasKey(x => new { x.GuideId, x.RegionId });

            builder.HasOne(x => x.Guide)
                   .WithMany(g => g.GuideRegions)
                   .HasForeignKey(x => x.GuideId);

            builder.HasOne(x => x.Region)
                   .WithMany(r => r.GuideRegions)
                   .HasForeignKey(x => x.RegionId);
        }
    }

}
