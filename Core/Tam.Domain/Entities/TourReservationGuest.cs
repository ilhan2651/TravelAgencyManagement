using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class TourReservationGuest : BaseEntity
    {
        public int TourReservationId { get; set; }
        public TourReservation TourReservation { get; set; }

        public string FullName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Note { get; set; }
    }
}