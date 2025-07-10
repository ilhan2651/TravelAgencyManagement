using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tam.Domain.Entities;

namespace Tam.Persistence.Configurations
{
    public class TourReservationGuestConfiguration : IEntityTypeConfiguration<TourReservationGuest>
    {
        public void Configure(EntityTypeBuilder<TourReservationGuest> builder)
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

            builder.HasOne(x => x.TourReservation)
                   .WithMany(tr => tr.Guests)
                   .HasForeignKey(x => x.TourReservationId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}