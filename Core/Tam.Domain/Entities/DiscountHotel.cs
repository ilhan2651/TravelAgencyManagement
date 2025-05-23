using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Domain.Entities
{
    public class DiscountHotel
    {
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }

        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
