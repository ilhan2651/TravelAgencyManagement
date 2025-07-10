using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Guide;

namespace Tam.Application.Dtos.TourReservationDtos
{
    public class TourReservationDetailDto
    {
        public string TourName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public string? DiscountName { get; set; }
        public int? PaymentId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public List<TourReservationGuestListDto> TourReservationGuestListDtos { get; set; }
    }
}
