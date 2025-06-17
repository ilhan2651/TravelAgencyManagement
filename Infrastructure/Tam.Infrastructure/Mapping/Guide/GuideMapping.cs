using AutoMapper;
using System.Linq;
using Tam.Domain.Entities;
using Tam.Application.Dtos.Guide;

namespace Tam.Infrastructure.Mapping
{
    public class GuideMapping : Profile
    {
        public GuideMapping()
        {

            CreateMap<Guide, ListGuideDto>()
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FullName))
                .ForMember(d => d., o => o.MapFrom(s => s.Region.Name))
                .ForMember(d => d.PrimaryLocationName,
                    o => o.MapFrom(s =>
                        s.GuideLocations
                         .Where(gl => gl.IsPrimary)
                         .Select(gl => gl.Location.Name)
                         .FirstOrDefault()))
                .ForMember(d => d.LocationCount,
                    o => o.MapFrom(s => s.GuideLocations.Count));

            CreateMap<Guide, GuideSearchResultDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FullName))
                .ForMember(d => d.RegionName,
                           o => o.MapFrom(s => s.Region.Name));

            CreateMap<Guide, GuideDetailDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.FullName, o => o.MapFrom(s => s.FullName))
                .ForMember(d => d.RegionName,
                           o => o.MapFrom(s => s.Region.Name))
                .ForMember(d => d.Locations,
                           o => o.MapFrom(s => s.GuideLocations)) 
                .ForMember(d => d.Languages,
                           o => o.MapFrom(s => s.GuideLanguages)); 

            CreateMap<GuideLocation, LocationMiniDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Location.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Location.Name))
                .ForMember(d => d.IsPrimary, o => o.MapFrom(s => s.IsPrimary));


            // Create
            CreateMap<CreateGuideDto, Guide>();

            CreateMap<UpdateGuideDto, Guide>()
                .ForAllMembers(o => o.Condition((src, dest, srcVal) => srcVal is not null));
        }
    }
}
