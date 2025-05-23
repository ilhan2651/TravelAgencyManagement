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
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Symbol).IsRequired();
            builder.Property(x => x.ExchangeRateToTRY).IsRequired(false);
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.UpdatedAt).HasDefaultValueSql("TIMEZONE('UTC', now())");

            builder.HasMany(x => x.Invoices)
                   .WithOne(x => x.Currency)
                   .HasForeignKey(i => i.CurrencyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
