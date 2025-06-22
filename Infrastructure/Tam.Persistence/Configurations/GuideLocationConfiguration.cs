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
    public class GuideLocationConfiguration : IEntityTypeConfiguration<GuideLocation>
    {
        public void Configure(EntityTypeBuilder<GuideLocation> builder)
        {
            builder.HasKey(x => new { x.GuideId, x.LocationId });

            builder.HasOne(x => x.Guide)
                   .WithMany(g => g.GuideLocations)
                   .HasForeignKey(x => x.GuideId);

            builder.HasOne(x => x.Location)
                   .WithMany(l => l.GuideLocations)
                   .HasForeignKey(x => x.LocationId);

            builder.Property(x => x.Note).HasMaxLength(300);
            builder.Property(x => x.IsPrimary).IsRequired();
        }
    }

}
