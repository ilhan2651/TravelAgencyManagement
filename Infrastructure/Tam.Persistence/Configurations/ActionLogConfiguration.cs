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
    public class ActionLogConfiguration : IEntityTypeConfiguration<ActionLog>
    {
        public void Configure(EntityTypeBuilder<ActionLog> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);
            builder.Property(x => x.ActionType).IsRequired();
            builder.Property(x => x.EntityName).IsRequired();
            builder.Property(x => x.EntityId).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.IpAddress).IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.ActionLogs)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
