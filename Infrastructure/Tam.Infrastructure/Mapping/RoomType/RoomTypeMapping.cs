using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.RoomType;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class RoomTypeMapping :Profile
    {
        public RoomTypeMapping()
        {
            CreateMap<RoomType, ListRoomTypeDto>();
            CreateMap<CreateRoomTypeDto, RoomType>();
            CreateMap<UpdateRoomTypeDto, RoomType>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));

        }
    }
}
