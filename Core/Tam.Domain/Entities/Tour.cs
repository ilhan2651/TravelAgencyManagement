using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int GuideId { get; set; }
        public Guide Guide { get; set; }
        public int ApranteeId { get; set; }
        public Apprantee Apprantee { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<TourVehicle>? TourVehicles { get; set; }
        public ICollection<TourDriver>? TourDrivers { get; set; }

    }
}
