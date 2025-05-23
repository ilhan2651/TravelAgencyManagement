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


    namespace Tam.Persistence.Configurations
    {
        public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
        {
            public void Configure(EntityTypeBuilder<Hotel> builder)
            {
                builder.HasKey(h => h.Id);

                builder.Property(h => h.Name)
                       .IsRequired()
                       .HasMaxLength(200);

                builder.Property(h => h.Address)
                       .IsRequired()
                       .HasMaxLength(300);

                builder.Property(h => h.Description)
                       .HasMaxLength(1000);

                builder.Property(h => h.PhoneNumber)
                       .HasMaxLength(50);

                builder.Property(h => h.Email)
                       .HasMaxLength(100);

                builder.Property(h => h.ImageUrl)
                       .HasMaxLength(255);

                builder.Property(h => h.Website)
                       .HasMaxLength(255);

                builder.Property(h => h.StarRating)
                       .IsRequired();

                builder.Property(h => h.PricePerNight)
                       .HasPrecision(10, 2);

                builder.Property(h => h.IsActive)
                       .HasDefaultValue(true);

                builder.Property(x => x.CreatedAt)
        .HasDefaultValueSql("TIMEZONE('UTC', now())");
                builder.Property(h => h.UpdatedAt).IsRequired(false);
                builder.Property(h => h.DeletedAt).IsRequired(false);

                builder.HasOne(h => h.Location)
                       .WithMany(l => l.Hotels)
                       .HasForeignKey(h => h.LocationId)
                       .OnDelete(DeleteBehavior.SetNull);

                builder.HasMany(h => h.HotelFacilities)
                       .WithOne(hf => hf.Hotel)
                       .HasForeignKey(hf => hf.HotelId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(h => h.HotelReservations)
                       .WithOne(hr => hr.Hotel)
                       .HasForeignKey(hr => hr.HotelId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasMany(h => h.HotelPurchases)
                       .WithOne(hp => hp.Hotel)
                       .HasForeignKey(hp => hp.HotelId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(h => h.DiscountHotels)
                       .WithOne(dh => dh.Hotel)
                       .HasForeignKey(dh => dh.HotelId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasMany(h => h.TourHotels)
                    .WithOne(th => th.Hotel)
                          .HasForeignKey(th => th.HotelId)
                          .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }

}
