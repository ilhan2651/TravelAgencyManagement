using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Discount : BaseEntity
    {

        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "Percentage";

        public decimal Value { get; set; }
        public decimal? MinAmount { get; set; }
        public bool IsActive { get; set; } = true;

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<DiscountTour>? DiscountTours { get; set; }
        public ICollection<DiscountHotel>? DiscountHotels { get; set; }
        public ICollection<DiscountTransfer>? DiscountTransfers { get; set; }
        public ICollection<TourReservation>? TourReservations { get; set; }
        public ICollection<TransferReservation>? TransferReservations { get; set; }
        public ICollection<HotelReservation>? HotelReservations { get; set; }



    }

}
