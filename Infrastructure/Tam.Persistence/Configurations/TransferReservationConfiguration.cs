using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class TransferReservationConfiguration : IEntityTypeConfiguration<TransferReservation>
    {
        public void Configure(EntityTypeBuilder<TransferReservation> builder)
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
                   .WithMany(c => c.TransferReservations)
                   .HasForeignKey(x => x.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Payment)
                   .WithMany(p => p.TransferReservations)
                   .HasForeignKey(x => x.PaymentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Transfer)
                   .WithMany(t => t.TransferReservations)
                   .HasForeignKey(x => x.TransferId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Discount)
                   .WithMany(d => d.TransferReservations)
                   .HasForeignKey(x => x.DiscountId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.Invoice)
                   .WithOne(i => i.TransferReservation)
                   .HasForeignKey<Invoice>(i => i.TransferReservationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
