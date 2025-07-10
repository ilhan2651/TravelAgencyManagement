using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TourReservationDtos
{
    public class UpdateTourReservationDto
    {
        public int TourId { get; set; }
        public int? InvoiceId { get; set; }
        public int? DiscountId { get; set; }
        public int? PaymentId { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public List<UpdateTourReservationGuestDto>? Guests { get; set; }
    }
}
