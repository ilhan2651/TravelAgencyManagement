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
    public class TransferConfiguration : IEntityTypeConfiguration<Transfer>
    {
        public void Configure(EntityTypeBuilder<Transfer> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.PassengerCount).IsRequired();
            builder.Property(x => x.IsCompleted).HasDefaultValue(false);
            builder.Property(x => x.StartTime).IsRequired();
            builder.Property(x => x.EndTime).IsRequired();
           
        builder.Property(x => x.StartLocationId).IsRequired(false);
            builder.Property(x => x.EndLocationId).IsRequired(false);
            builder.Property(x => x.RouteId).IsRequired();
            builder.Property(x => x.AppranteeId).IsRequired();
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);


            builder.HasOne(x => x.Apprantee)
                   .WithMany(x => x.Transfers)
                   .HasForeignKey(x => x.AppranteeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Route)
                   .WithMany()
                   .HasForeignKey(x => x.RouteId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.StartLocation)
                   .WithMany(l=>l.StartTransfers)
                   .HasForeignKey(x => x.StartLocationId)
                    .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.EndLocation)
                   .WithMany(l=>l.EndTransfers)
                   .HasForeignKey(x => x.EndLocationId)
                   .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.TransferReservations)
                .WithOne(x => x.Transfer)
                     .HasForeignKey(x => x.TransferId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DriverTransfers)
                .WithOne(x => x.Transfer)
                     .HasForeignKey(x => x.TransferId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.AffiliateTransferSales)
                .WithOne(x => x.Transfer)
                     .HasForeignKey(x => x.TransferId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.DiscountTransfers)
                .WithOne(x => x.Transfer)
                     .HasForeignKey(x => x.TransferId)
                     .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.TransferVehicles)
                .WithOne(x => x.Transfer)
                     .HasForeignKey(x => x.TransferId)
                     .OnDelete(DeleteBehavior.Cascade);

         


        }
    }

}
