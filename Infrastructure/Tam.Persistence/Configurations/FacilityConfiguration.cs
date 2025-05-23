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
    public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasKey(f => f.Id);

            builder.Property(x => x.CreatedAt)
       .HasDefaultValueSql("TIMEZONE('UTC', now())");


            builder.Property(f => f.UpdatedAt)
                   .IsRequired(false);

            builder.Property(f => f.DeletedAt)
                   .IsRequired(false);

            builder.HasMany(f => f.HotelFacilities)
                  .WithOne(hf => hf.Facility)
                  .HasForeignKey(hf => hf.FacilityId)
                  .OnDelete(DeleteBehavior.Cascade); 
        }

    }
}
