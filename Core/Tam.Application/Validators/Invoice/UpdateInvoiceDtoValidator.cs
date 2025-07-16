using FluentValidation;
using Tam.Application.Dtos.InvoiceDtos;

namespace Tam.Application.Validators.Invoice
{
    public class UpdateInvoiceDtoValidator : AbstractValidator<UpdateInvoiceDto>
    {
        public UpdateInvoiceDtoValidator()
        {
            RuleFor(x => x.InvoiceNumber)
                .NotEmpty().WithMessage("Fatura numarası zorunludur.")
                .MaximumLength(50).WithMessage("Fatura numarası en fazla 50 karakter olabilir.");

            RuleFor(x => x.CustomerId)
                .GreaterThan(0).WithMessage("Geçerli bir müşteri seçiniz.");

            RuleFor(x => x.InvoiceDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Fatura tarihi bugünden ileri olamaz.");

            RuleFor(x => x.CurrencyId)
                .GreaterThan(0).When(x => x.CurrencyId.HasValue)
                .WithMessage("Geçerli bir para birimi seçiniz.");

            RuleFor(x => x.PaymentId)
                .GreaterThan(0).When(x => x.PaymentId.HasValue)
                .WithMessage("Geçerli bir ödeme seçiniz.");

            RuleFor(x => x.TourReservationId)
                .GreaterThan(0).When(x => x.TourReservationId.HasValue)
                .WithMessage("Geçerli bir tur rezervasyonu seçiniz.");

            RuleFor(x => x.HotelReservationId)
                .GreaterThan(0).When(x => x.HotelReservationId.HasValue)
                .WithMessage("Geçerli bir otel rezervasyonu seçiniz.");

            RuleFor(x => x.TransferReservationId)
                .GreaterThan(0).When(x => x.TransferReservationId.HasValue)
                .WithMessage("Geçerli bir transfer rezervasyonu seçiniz.");

            RuleFor(x => x.PdfUrl)
                .MaximumLength(255).When(x => !string.IsNullOrWhiteSpace(x.PdfUrl))
                .WithMessage("PDF adresi en fazla 255 karakter olabilir.");
        }
    }
}
