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
    public class DiscountTourConfiguration : IEntityTypeConfiguration<DiscountTour>
    {
        public void Configure(EntityTypeBuilder<DiscountTour> builder)
        {
            builder.HasKey(x => new { x.DiscountId, x.TourId });

            builder.HasOne(x => x.Discount)
                   .WithMany(d => d.DiscountTours)
                   .HasForeignKey(x => x.DiscountId);

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.DiscountTours)
                   .HasForeignKey(x => x.TourId);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");

        }
    }
}
