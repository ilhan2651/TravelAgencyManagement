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
    public class AffiliatePartnerConfiguration : IEntityTypeConfiguration<AffiliatePartner>
    {
        public void Configure(EntityTypeBuilder<AffiliatePartner> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ContactName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();
            builder.Property(x => x.Address).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasMany(x => x.AffiliateTourSales)
                .WithOne(x => x.AffiliatePartner)
                .HasForeignKey(x => x.AffiliatePartnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.AffiliateTransferSales)
                .WithOne(x => x.AffiliatePartner)
                .HasForeignKey(x => x.AffiliatePartnerId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
