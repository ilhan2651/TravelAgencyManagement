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
    public class GuideConfiguration : IEntityTypeConfiguration<Guide>
    {
        public void Configure(EntityTypeBuilder<Guide> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PhoneNumber).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(300);
            builder.Property(x => x.Image).HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasMany(g => g.Tours)
                   .WithOne(t => t.Guide)
                   .HasForeignKey(t => t.GuideId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.GuideLocations)
                   .WithOne(gl => gl.Guide)
                   .HasForeignKey(gl => gl.GuideId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(g => g.GuideRegions)
                   .WithOne(gr => gr.Guide)
                   .HasForeignKey(gr => gr.GuideId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
