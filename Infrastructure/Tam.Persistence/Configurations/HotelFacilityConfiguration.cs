using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Persistence.Configurations
{
    public class HotelFacilityConfiguration : IEntityTypeConfiguration<HotelFacility>
    {
        public void Configure(EntityTypeBuilder<HotelFacility> builder)
        {
            builder.HasKey(hf => new { hf.HotelId, hf.FacilityId });

            builder.HasOne(hf => hf.Hotel)
                   .WithMany(h => h.HotelFacilities)
                   .HasForeignKey(hf => hf.HotelId)
                   .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(hf => hf.Facility)
                   .WithMany(f => f.HotelFacilities)
                   .HasForeignKey(hf => hf.FacilityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
