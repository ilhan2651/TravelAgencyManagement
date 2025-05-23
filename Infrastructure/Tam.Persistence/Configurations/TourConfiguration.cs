using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Capacity).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.GuideId).IsRequired();

            builder.HasOne(x => x.Guide)
                .WithMany(x => x.Tours)
                .HasForeignKey(x => x.GuideId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(x=>x.DeletedAt).IsRequired(false);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);


            builder.HasOne(x => x.Apprantee)
                .WithMany(x => x.Tours)
                .HasForeignKey(x => x.AppranteeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.AppranteeId).IsRequired();

            builder.HasOne(x => x.Route)
                .WithMany(x => x.Tours)
                .HasForeignKey(x => x.RouteId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.RouteId).IsRequired(false);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Tours)
                .HasForeignKey(x => x.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Property(x => x.CategoryId).IsRequired(false);

            builder.HasOne(x => x.StartLocation)
                    .WithMany(x=>x.StartTours)
                    .HasForeignKey(x => x.StartLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Tour_StartLocation");
            builder.Property(x => x.StartLocationId).IsRequired(false);

            builder.HasOne(x => x.EndLocation)
                   .WithMany(x=>x.EndTours)
                   .HasForeignKey(x => x.EndLocationId)
                   .OnDelete(DeleteBehavior.Restrict)
                   .HasConstraintName("FK_Tour_EndLocation");
            builder.Property(x => x.EndLocationId).IsRequired(false);

            builder.HasMany(t=>t.TourVehicles)
                .WithOne(t => t.Tour)
                .HasForeignKey(t => t.TourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TourDrivers)
                .WithOne(t => t.Tour)
                .HasForeignKey(t => t.TourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TourRegions)
                .WithOne(t => t.Tour)
                .HasForeignKey(t => t.TourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TourHotels)
                .WithOne(t => t.Tour)
                .HasForeignKey(t => t.TourId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.TourReservations)
                .WithOne(t => t.Tour)
                .HasForeignKey(t => t.TourId)  
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(t => t.AffiliateTourSales)
                .WithOne(t => t.Tour)
                .HasForeignKey(t => t.TourId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
