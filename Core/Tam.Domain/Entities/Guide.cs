using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;
namespace Tam.Domain.Entities

{
    public class Guide : BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public ICollection<GuideLocation> GuideLocations { get; set; }
        public ICollection<GuideRegion> GuideRegions { get; set; }


    }
}
