using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelDtos
{
    public class HotelSearchResultDto
    {
        public string Name { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int StarRating { get; set; }
        public string LocationName { get; set; } = string.Empty;

    }
}
