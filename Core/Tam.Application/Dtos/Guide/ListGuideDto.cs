using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public ICollection<GuideLocation> GuideLocations { get; set; }
        public ICollection<GuideRegion> GuideRegions { get; set; }
    }
}
