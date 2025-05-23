using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Transfer : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int AppranteeId { get; set; }
        public Apprantee Apprantee { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public DateTime StartTime { get; set; } 
        public DateTime EndTime { get; set; }
        public int PassengerCount { get; set; }
        public bool IsCompleted { get; set; } = false;
        public int? StartLocationId { get; set; }
        [ForeignKey(nameof(StartLocationId))]
        public Location? StartLocation { get; set; }
        public int? EndLocationId { get; set; }
        [ForeignKey(nameof(EndLocationId))]
        public Location? EndLocation { get; set; }
        public ICollection<TransferReservation>? TransferReservations { get; set; }
        public ICollection<DriverTransfer>? DriverTransfers { get; set; }
        public ICollection<AffiliateTransferSale>? AffiliateTransferSales { get; set; }
        public ICollection<DiscountTransfer>? DiscountTransfers { get; set; }
        public ICollection<TransferVehicle> TransferVehicles{ get; set; }

    }
}
