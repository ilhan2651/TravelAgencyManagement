using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class TourReservationConfiguration : IEntityTypeConfiguration<TourReservation>
    {
        public void Configure(EntityTypeBuilder<TourReservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ReservationDate).IsRequired();
            builder.Property(x => x.NumberOfPeople).IsRequired();
            builder.Property(x => x.TotalPrice).IsRequired();
            builder.Property(x => x.Status).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasOne(x => x.Customer)
                   .WithMany(c => c.TourReservations)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payment)
                   .WithMany(p => p.TourReservations)
                   .HasForeignKey(x => x.PaymentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Tour)
                   .WithMany(t => t.TourReservations)
                   .HasForeignKey(x => x.TourId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Discount)
                   .WithMany(d => d.TourReservations)
                   .HasForeignKey(x => x.DiscountId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Invoice)
                   .WithOne(i => i.TourReservation)
                   .HasForeignKey<Invoice>(i => i.TourReservationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
