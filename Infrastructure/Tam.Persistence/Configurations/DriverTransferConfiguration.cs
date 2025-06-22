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
    public class DriverTransferConfiguration : IEntityTypeConfiguration<DriverTransfer>
    {
        public void Configure(EntityTypeBuilder<DriverTransfer> builder)
        {
            builder.HasKey(x => new { x.DriverId, x.TransferId });

            builder.HasOne(x => x.Driver)
                   .WithMany(d => d.DriverTransfers)
                   .HasForeignKey(x => x.DriverId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Transfer)
                   .WithMany(t => t.DriverTransfers)
                   .HasForeignKey(x => x.TransferId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
