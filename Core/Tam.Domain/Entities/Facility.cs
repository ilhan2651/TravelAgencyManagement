using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class Facility : BaseEntity
    {
        public string Name { get; set; }=string.Empty;
        public ICollection<HotelFacility> HotelFacilities { get; set; }


    }
}
 