using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class AuditTrailConfiguration : IEntityTypeConfiguration<AuditTrail>
    {
        public void Configure(EntityTypeBuilder<AuditTrail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EntityName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.EntityId)
                   .IsRequired();

            builder.Property(x => x.ActionType)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Username)
                   .HasMaxLength(100);

            builder.Property(x => x.OldValues)
                   .HasColumnType("text");

            builder.Property(x => x.NewValues)
                   .HasColumnType("text");

            builder.Property(x => x.IpAddress)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.ActionTime)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())");

            builder.HasOne(x => x.User)
                   .WithMany(u => u.AuditTrails)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
