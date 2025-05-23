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


    public class AppranteeConfiguration : IEntityTypeConfiguration<Apprantee>
    {
        public void Configure(EntityTypeBuilder<Apprantee> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FullName).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.PhoneNumber).IsRequired();

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasMany(a => a.Tours)
                   .WithOne(t => t.Apprantee)
                   .HasForeignKey(t => t.AppranteeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(a => a.Transfers)
                   .WithOne(t => t.Apprantee)
                   .HasForeignKey(t => t.AppranteeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
