using AutoMapper;
using System.Linq;
using Tam.Application.Dtos.RouteDtos;
using Tam.Domain.Entities;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Infrastructure.Mapping
{
    public class RouteMapping : Profile
    {
        public RouteMapping()
        {
            CreateMap<Route, RouteListDto>()
                .ForMember(dest => dest.StartLocationName,
                    opt => opt.MapFrom(src =>
                        src.StartLocation != null
                            ? $"{src.StartLocation.City} - {src.StartLocation.Name}"
                            : null))
                .ForMember(dest => dest.EndLocationName,
                    opt => opt.MapFrom(src =>
                        src.EndLocation != null
                            ? $"{src.EndLocation.City} - {src.EndLocation.Name}"
                            : null));

            CreateMap<Route, RouteDetailDto>()
                .ForMember(dest => dest.StartLocationName,
                    opt => opt.MapFrom(src =>
                        src.StartLocation != null
                            ? $"{src.StartLocation.City} - {src.StartLocation.Name}"
                            : null))
                .ForMember(dest => dest.EndLocationName,
                    opt => opt.MapFrom(src =>
                        src.EndLocation != null
                            ? $"{src.EndLocation.City} - {src.EndLocation.Name}"
                            : null))
                .ForMember(dest => dest.RouteStops,
                    opt => opt.MapFrom(src => src.RouteStops.OrderBy(rs => rs.Order)));

            CreateMap<RouteStop, RouteStopDetailDto>()
                .ForMember(dest => dest.LocationName,
                    opt => opt.MapFrom(src =>
                        src.Location != null
                            ? $"{src.Location.City} - {src.Location.Name}"
                            : null));

            CreateMap<RouteStopDto, RouteStop>();
            CreateMap<CreateRouteDto, Route>();
            CreateMap<UpdateRouteDto, Route>();
        }
    }
}
