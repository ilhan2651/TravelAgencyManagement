using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class HotelPurchase : BaseEntity
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public int HotelReservationId { get; set; }
        public HotelReservation HotelReservation { get; set; }
        public  decimal  CostToAgency { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Note { get; set; }
        public bool IsPaid { get; set; }

    }
}
