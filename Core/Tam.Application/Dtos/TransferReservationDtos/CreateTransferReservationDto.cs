using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.TransferReservationDtos
{
    public class CreateTransferReservationDto
    {
        public int NumberOfPeople { get; set; }
        public int TotalPrice { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public int TransferId { get; set; }
        public string PickUpPoint { get; set; } = string.Empty;
        public string DropOffPoint { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public int? DiscountId { get; set; }
        public int? PaymentId { get; set; }
        public int? InvoiceId { get; set; }
        public List<CreateTransferReservationGuestsDto> Guests { get; set; } = [];

    }

}
