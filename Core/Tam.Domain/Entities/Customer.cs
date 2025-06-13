using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public bool IsDeleted => DeletedAt.HasValue;

        public ICollection<HotelReservation>? HotelReservations { get; set; }
        public ICollection<TourReservation>? TourReservations { get; set; }
        public ICollection<TransferReservation>? TransferReservations { get; set; }
        public ICollection<Invoice>? Invoices { get; set; }

    }
}
