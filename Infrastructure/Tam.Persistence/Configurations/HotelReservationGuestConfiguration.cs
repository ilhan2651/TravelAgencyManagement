using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class HotelReservationGuestConfiguration : IEntityTypeConfiguration<TransferReservationGuest>
    {
        public void Configure(EntityTypeBuilder<TransferReservationGuest> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Age)
                   .IsRequired();

            builder.Property(x => x.IdentityNumber)
                   .HasMaxLength(20);

            builder.Property(x => x.Note)
                   .HasMaxLength(500);

            builder.HasOne(x => x.HotelReservation)
                   .WithMany(hr => hr.Guests)
                   .HasForeignKey(x => x.HotelReservationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
