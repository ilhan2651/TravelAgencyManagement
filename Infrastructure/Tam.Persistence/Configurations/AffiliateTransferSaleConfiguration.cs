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
    public class AffiliateTransferSaleConfiguration: IEntityTypeConfiguration<AffiliateTransferSale>
    {
        public void Configure(EntityTypeBuilder<AffiliateTransferSale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);
            builder.Property(x => x.NumberOfPeople).IsRequired();
            builder.Property(x => x.CommissionRate).IsRequired().HasPrecision(5,4);
            builder.Property(x => x.TotalCommissionAmount).IsRequired().HasPrecision(18,2);
            builder.Property(x => x.SaleDate).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.AffiliatePartnerId).IsRequired();
            builder.Property(x => x.TransferId).IsRequired();

            builder.HasOne(x => x.Transfer)
                .WithMany(x => x.AffiliateTransferSales)
                .HasForeignKey(x => x.TransferId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.AffiliatePartner)
                .WithMany(x => x.AffiliateTransferSales)
                .HasForeignKey(x => x.AffiliatePartnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
