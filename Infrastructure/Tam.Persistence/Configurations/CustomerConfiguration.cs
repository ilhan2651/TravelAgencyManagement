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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Address).IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasMany(x => x.HotelReservations)
                   .WithOne(r => r.Customer)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.TransferReservations)
                .WithOne(r => r.Customer)
                     .HasForeignKey(r => r.CustomerId)
                     .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.TourReservations)
                .WithOne(r => r.Customer)
                     .HasForeignKey(r => r.CustomerId)
                     .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
