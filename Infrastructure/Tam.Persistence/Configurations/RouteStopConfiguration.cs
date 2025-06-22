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
    public class RouteStopConfiguration : IEntityTypeConfiguration<RouteStop>
    {
        public void Configure(EntityTypeBuilder<RouteStop> builder)
        {

            builder.HasKey(rs => new { rs.RouteId, rs.LocationId });
            builder.Property(rs => rs.StopDuration)
                .HasColumnType("time");
            builder.Property(rs => rs.Note)
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.Property(rs => rs.Order)
                .IsRequired();
            builder.HasOne(rs => rs.Route)
                .WithMany(r => r.RouteStops)
                .HasForeignKey(rs => rs.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(rs => rs.Location)
                .WithMany()
                .HasForeignKey(rs => rs.LocationId)
                .OnDelete(DeleteBehavior.Cascade);


              
     
        }
    }

}
