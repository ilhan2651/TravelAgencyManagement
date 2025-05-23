using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class TourHotelConfiguration : IEntityTypeConfiguration<TourHotel>
    {
       public void Configure(EntityTypeBuilder<TourHotel> builder)
        {
            builder.HasKey(x => new { x.TourId, x.HotelId });

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.TourHotels)
                   .HasForeignKey(x => x.TourId);

            builder.HasOne(x => x.Hotel)
                   .WithMany(h => h.TourHotels)
                   .HasForeignKey(x => x.HotelId);
        }
    }
}
