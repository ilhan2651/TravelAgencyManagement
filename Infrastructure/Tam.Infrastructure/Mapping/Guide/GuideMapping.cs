using AutoMapper;
using System.Linq;
using Tam.Domain.Entities;
using Tam.Application.Dtos.Guide;
using Tam.Application.Dtos.GuideLocation;
using Tam.Application.Dtos.GuideRegion;
using Tam.Application.Dtos.Tour;

namespace Tam.Infrastructure.Mapping
{
    public class GuideMapping : Profile
    {
        public GuideMapping()
        {

            CreateMap<Location, GuideLocationDto>();
      

            CreateMap<GuideLocation, GuideLocationDto>()
         .ForMember(d => d.Id, o => o.MapFrom(s => s.Location.Id))
         .ForMember(d => d.Country, o => o.MapFrom(s => s.Location.Country))
         .ForMember(d => d.City, o => o.MapFrom(s => s.Location.City))
         .ForMember(d => d.District, o => o.MapFrom(s => s.Location.District))
         .ForMember(d => d.IsPrimary, o => o.MapFrom(s => s.IsPrimary));

            CreateMap<Region, GuideRegionDto>();

            CreateMap<GuideRegion, GuideRegionDto>()
         .ForMember(d => d.Id, o => o.MapFrom(s => s.Region.Id))
         .ForMember(d => d.Name, o => o.MapFrom(s => s.Region.Name));

            CreateMap<Tour, TourMiniDto>();

            CreateMap<Guide, ListGuideDto>()
         .ForMember(d => d.Locations,
                    o => o.MapFrom(s => s.GuideLocations))
         .ForMember(d => d.Regions,
                    o => o.MapFrom(s => s.GuideRegions));
            CreateMap<Guide, GuideDetailDto>()
          .IncludeBase<Guide, ListGuideDto>()         
          .ForMember(d => d.Tours,
                     o => o.MapFrom(s => s.Tours));

            CreateMap<Guide, GuideSearchResultDto>();
            CreateMap<CreateGuideDto, Guide>();
            CreateMap<UpdateGuideDto, Guide>()
                .ForAllMembers(opt => opt.Condition((src, _, value) => value is not null));
        }
    }
}
