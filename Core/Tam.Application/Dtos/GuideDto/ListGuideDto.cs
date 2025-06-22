using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.GuideLocation;
using Tam.Application.Dtos.GuideRegion;
using Tam.Domain.Entities;

namespace Tam.Application.Dtos.Guide
{
    public class ListGuideDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public DateTime? DeletedAt { get; set; }
        public ICollection<GuideLocationDto> Locations { get; set; } = [];
        public ICollection<GuideRegionDto> Regions { get; set; } = [];
    }
}
