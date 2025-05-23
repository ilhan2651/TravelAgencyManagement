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
    public class DiscountHotelConfiguration : IEntityTypeConfiguration<DiscountHotel>
    {
        public void Configure(EntityTypeBuilder<DiscountHotel> builder)
        {
            builder.HasKey(x => new { x.DiscountId, x.HotelId });

            builder.HasOne(x => x.Discount)
                   .WithMany(d => d.DiscountHotels)
                   .HasForeignKey(x => x.DiscountId);

            builder.HasOne(x => x.Hotel)
                   .WithMany(h => h.DiscountHotels)
                   .HasForeignKey(x => x.HotelId);

            builder.Property(x => x.CreatedAt)
        .HasDefaultValueSql("TIMEZONE('UTC', now())");

        }
    }

}
