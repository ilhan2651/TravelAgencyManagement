using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class TransferReservation : Reservation
    {
        public int TransferId { get; set; }
        public Transfer Transfer { get; set; }
        public string PickUpPoint { get; set; }=string.Empty;
        public string DropOffPoint { get; set; }=string.Empty;
        public int? InvoiceId { get; set; }
        public Invoice? Invoice { get; set; }

        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
        public int? PaymentId { get; set; }
        public Payment? Payment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
