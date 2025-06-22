using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Domain.Common;

namespace Tam.Domain.Entities
{
    public class HotelRoomOption : BaseEntity
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }

        public decimal PricePerNight { get; set; }
        public int Capacity { get; set; }
    }

}
