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
    public class ReportRequestConfiguration : IEntityTypeConfiguration<ReportRequest>
    {
        public void Configure(EntityTypeBuilder<ReportRequest> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReportType).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Format).HasDefaultValue("PDF").HasMaxLength(50);
            builder.Property(x => x.Status).HasDefaultValue("Pending").HasMaxLength(50);
            builder.Property(x => x.DownloadUrl).HasMaxLength(500);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);
            builder.Property(x=>x.StartDate).IsRequired(false);
            builder.Property(x=>x.EndDate).IsRequired(false);


            builder.HasOne(x => x.User)
                   .WithMany(u => u.ReportRequests)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
