using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class HotelReservationRoomOptionConfiguration : IEntityTypeConfiguration<HotelReservationRoomOption>
    {
        public void Configure(EntityTypeBuilder<HotelReservationRoomOption> builder)
        {
            builder.HasKey(e => new { e.HotelReservationId, e.HotelRoomOptionId });

            builder.HasOne(e => e.HotelReservation)
                .WithMany(hr => hr.ReservedRooms)
                .HasForeignKey(e => e.HotelReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.HotelRoomOption)
                .WithMany()
                .HasForeignKey(e => e.HotelRoomOptionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.Quantity)
                .IsRequired();
        }
    }
}
