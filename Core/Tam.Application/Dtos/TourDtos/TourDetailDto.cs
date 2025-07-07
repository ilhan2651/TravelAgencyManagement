using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.TourDtos
{
    
        public class TourDetailDto : TourListDto
        {
            public int Capacity { get; set; }
            public string ImageUrl { get; set; } = string.Empty;
            public string? AppranteeName { get; set; }
            public TourRouteDto? Route { get; set; }
            public ICollection<TourVehicleDto> Vehicles { get; set; } = [];
            public ICollection<TourDriverDto> Drivers { get; set; } = [];
            public ICollection<TourHotelDto> Hotels { get; set; } = [];
            public ICollection<TourRegionDto> Regions { get; set; } = [];
            public DateTime CreatedAt { get; set; }
            public DateTime? UpdatedAt { get; set; }
            public DateTime? DeletedAt { get; set; }
        }
    
}
