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
    public class TransferVehicleConfiguration : IEntityTypeConfiguration<TransferVehicle>
    {
        public void Configure(EntityTypeBuilder<TransferVehicle> builder)
        {
            builder.HasKey(x => new { x.TransferId, x.VehicleId });

            builder.HasOne(x => x.Transfer)
                   .WithMany(t => t.TransferVehicles)
                   .HasForeignKey(x => x.TransferId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Vehicle)
                   .WithMany(v => v.TransferVehicles)
                   .HasForeignKey(x => x.VehicleId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
