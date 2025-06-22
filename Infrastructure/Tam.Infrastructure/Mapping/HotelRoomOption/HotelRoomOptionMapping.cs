using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.HotelRoomOptionDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class HotelRoomOptionMapping : Profile
    {
        public HotelRoomOptionMapping()
        {
            CreateMap<CreateHotelRoomOptionDto, HotelRoomOption>();
            CreateMap<UpdateHotelRoomOptionDto, HotelRoomOption>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));

            CreateMap<HotelRoomOption, ListHotelRoomOptionDto>()
                .ForMember(d => d.RoomTypeName, opt => opt.MapFrom(s => s.RoomType.Name));

        }
    }
}
