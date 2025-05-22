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
        public Invoice? Invoice { get; set; }
    }
}
