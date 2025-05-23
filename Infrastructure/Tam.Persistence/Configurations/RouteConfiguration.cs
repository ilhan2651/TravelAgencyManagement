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
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsActive).IsRequired().HasDefaultValue(true);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.DeletedAt).IsRequired(false);
            builder.Property(x => x.UpdatedAt).IsRequired(false);


            builder.Property(x => x.StartLocationId)
                   .IsRequired(false);
            builder.Property(x => x.EndLocationId)
                .IsRequired(false);
                 

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.HasOne(x => x.StartLocation)
                   .WithMany(l => l.StartRoutes)
                   .HasForeignKey(x => x.StartLocationId);

            builder.HasOne(x => x.EndLocation)
                   .WithMany(l => l.EndRoutes)
                   .HasForeignKey(x => x.EndLocationId);


            builder.HasMany(x => x.RouteStops)
                   .WithOne(rs => rs.Route)
                   .HasForeignKey(rs => rs.RouteId);

            builder.HasMany(x => x.Tours)
                   .WithOne(t => t.Route)
                   .HasForeignKey(t => t.RouteId);
        }
    }

}
