using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Facility;
using Tam.Application.Dtos.HotelDtos;
using Tam.Domain.Entities;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Infrastructure.Mapping
{
    public class HotelMapping : Profile
    {
        public HotelMapping()
        {
            CreateMap<HotelFacility, FacilityDtoForHotel>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Facility.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Facility.Name));

            CreateMap<Hotel, ListHotelDto>()
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s =>
                    s.Location != null
                        ? $"{s.Location.City} - {s.Location.District}"
                        : string.Empty
                ));

            CreateMap<Hotel, HotelDetailDto>()
                .IncludeBase<Hotel, ListHotelDto>()
                .ForMember(d => d.Facilities, opt => opt.MapFrom(s => s.HotelFacilities));

            CreateMap<Hotel, HotelSearchResultDto>()
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s =>
                    s.Location != null
                        ? $"{s.Location.City} - {s.Location.District}"
                        : string.Empty
                ));

            CreateMap<CreateHotelDto, Hotel>();
            CreateMap<UpdateHotelDto, Hotel>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));
        }
    }

}
