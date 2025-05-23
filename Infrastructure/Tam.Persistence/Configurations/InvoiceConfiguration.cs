    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Tam.Domain.Entities;

    namespace Tam.Persistence.Configurations
    {
        public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
        {
            public void Configure(EntityTypeBuilder<Invoice> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(x => x.InvoiceNumber)
                       .IsRequired()
                       .HasMaxLength(50);

                builder.Property(x => x.InvoiceDate)
                       .HasDefaultValueSql("TIMEZONE('UTC', now())");

                builder.Property(x => x.TotalAmount)
                       .HasPrecision(10, 2)
                       .IsRequired();

                builder.Property(x => x.TaxAmount)
                       .HasPrecision(10, 2)
                       .IsRequired();

                builder.Property(x => x.SubTotal)
                       .HasPrecision(10, 2)
                       .IsRequired();

                builder.Property(x => x.IsPaid)
                       .HasDefaultValue(false);

                builder.Property(x => x.PdfUrl)
                       .HasMaxLength(255);

            builder.Property(x => x.CreatedAt)
   .HasDefaultValueSql("TIMEZONE('UTC', now())");
            builder.Property(x => x.UpdatedAt).IsRequired(false);
                builder.Property(x => x.DeletedAt).IsRequired(false);

                builder.HasOne(x => x.Customer)
                       .WithMany(c => c.Invoices) 
                       .HasForeignKey(x => x.CustomerId)
                       .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(x => x.Currency)
                       .WithMany(c => c.Invoices)
                       .HasForeignKey(x => x.CurrencyId)
                       .OnDelete(DeleteBehavior.SetNull);

                builder.HasOne(x => x.Payment)
                       .WithMany()
                       .HasForeignKey(x => x.PaymentId)
                       .OnDelete(DeleteBehavior.SetNull);

                builder.HasOne(x => x.TourReservation)
                       .WithOne(tr => tr.Invoice)
                       .HasForeignKey<Invoice>(x => x.TourReservationId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x => x.HotelReservation)
                       .WithOne(hr => hr.Invoice)
                       .HasForeignKey<Invoice>(x => x.HotelReservationId)
                       .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x => x.TransferReservation)
                       .WithOne(tr => tr.Invoice)
                       .HasForeignKey<Invoice>(x => x.TransferReservationId)
                       .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }


