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
    public class TaxDetailConfiguration : IEntityTypeConfiguration<TaxDetail>
    {
        public void Configure(EntityTypeBuilder<TaxDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TaxDocumentUrl).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Amount).HasPrecision(10, 2);
            builder.Property(x => x.WhoPaid).IsRequired().HasMaxLength(100);
            builder.Property(x => x.IsPaid).HasDefaultValue(false);
            builder.Property(x => x.PaidAt).IsRequired(false);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);
        }
    }

}
