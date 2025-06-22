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
    public class HotelRoomOptionConfiguration : IEntityTypeConfiguration<HotelRoomOption>
    {
        public void Configure(EntityTypeBuilder<HotelRoomOption> builder)
        {
            {
                builder.HasKey(e => e.Id);

                builder.HasOne(e => e.Hotel)
                    .WithMany(h => h.RoomOptions)
                    .HasForeignKey(e => e.HotelId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(e => e.RoomType)
                    .WithMany(rt => rt.HotelRoomOptions)
                    .HasForeignKey(e => e.RoomTypeId)
                    .OnDelete(DeleteBehavior.Cascade);

                builder.Property(e => e.PricePerNight)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                builder.Property(e => e.Capacity)
                    .IsRequired();
            };

        }


    }
}
