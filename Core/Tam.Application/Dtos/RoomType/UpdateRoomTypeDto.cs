using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tam.Application.Dtos.RoomType
{
    public class UpdateRoomTypeDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

}
