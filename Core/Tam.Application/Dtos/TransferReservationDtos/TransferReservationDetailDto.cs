using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.TransferReservationDtos
{
    public class TransferReservationDetailDto
    {
        public string TransferName { get; set; }
        public string PickUpPoint { get; set; } = string.Empty;
        public string DropOffPoint { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime ReservationDate { get; set; } = DateTime.UtcNow;
        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; }
        public string Note { get; set; } = string.Empty;
        public string DiscountName { get; set; }
        public int? PaymentId { get; set; }
        public string CustomerName { get; set; }
        public ICollection<TransferReservationGuestListDto> Guests { get; set; } = new List<TransferReservationGuestListDto>();
    }
}
