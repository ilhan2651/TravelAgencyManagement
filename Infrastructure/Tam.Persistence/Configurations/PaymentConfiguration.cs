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
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Amount).HasPrecision(10, 2).IsRequired();
            builder.Property(x => x.IsPaid).IsRequired();
            builder.Property(x => x.IsRefunded).IsRequired().HasDefaultValue(false);
            builder.Property(x => x.PaidAt).IsRequired();
            builder.Property(x => x.TransactionCode).HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasMany(p => p.HotelReservations)
                   .WithOne(r => r.Payment)
                   .HasForeignKey(r => r.PaymentId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.TourReservations)
                .WithOne(r => r.Payment)
                     .HasForeignKey(r => r.PaymentId)
                     .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.TransferReservations)
                    .WithOne(r => r.Payment)
                .HasForeignKey(r => r.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);


            builder.HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodId)
                .OnDelete(DeleteBehavior.SetNull); 

        }
    }

}
