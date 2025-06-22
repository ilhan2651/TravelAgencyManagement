using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Facility;

namespace Tam.Application.Dtos.HotelDtos
{
    public class HotelDetailDto : ListHotelDto
    {
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public ICollection<FacilityDtoForHotel> Facilities { get; set; } = [];

    }

}
