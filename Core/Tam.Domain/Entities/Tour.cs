using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Domain.Entities
{
    public class Tour : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int GuideId { get; set; }
        public Guide Guide { get; set; }
        public int AppranteeId { get; set; }
        public Apprantee Apprantee { get; set; }
        public int? RouteId { get; set; }
        public Route? Route { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? StartLocationId { get; set; }
        public Location? StartLocation { get; set; }
        public int? EndLocationId { get; set; }
        public Location? EndLocation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<TourVehicle>? TourVehicles { get; set; }
        public ICollection<TourDriver>? TourDrivers { get; set; }
        public ICollection<TourRegion>? TourRegions { get; set; }
        public ICollection<TourHotel>? TourHotels { get; set; }
        public ICollection<TourReservation>? TourReservations { get; set; }
        public ICollection<AffiliateTourSale>? AffiliateTourSales { get; set; }
        public ICollection<DiscountTour>? DiscountTours { get; set; }





    }
}
