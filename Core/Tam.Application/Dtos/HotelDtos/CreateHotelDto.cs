using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.HotelDtos
{
    public class CreateHotelDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public decimal PricePerNight { get; set; }
        public int? LocationId { get; set; }
        public bool IsActive { get; set; }

    }

}
