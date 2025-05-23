using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class HotelPurchaseConfiguration : IEntityTypeConfiguration<HotelPurchase>
    {
        public void Configure(EntityTypeBuilder<HotelPurchase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CostToAgency)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(x => x.PaymentDate)
                   .IsRequired();

            builder.Property(x => x.Note)
                   .HasMaxLength(500);

            builder.Property(x => x.IsPaid)
                   .HasDefaultValue(false);

            builder.Property(x => x.CreatedAt)
                   .HasDefaultValueSql("TIMEZONE('UTC', now())"); builder.Property(x => x.UpdatedAt).IsRequired(false);
            builder.Property(x => x.DeletedAt).IsRequired(false);

            builder.HasOne(x => x.Hotel)
                   .WithMany(h => h.HotelPurchases)
                   .HasForeignKey(x => x.HotelId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.HotelReservation)
                   .WithOne(r => r.HotelPurchase)
                   .HasForeignKey<HotelPurchase>(x => x.HotelReservationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
