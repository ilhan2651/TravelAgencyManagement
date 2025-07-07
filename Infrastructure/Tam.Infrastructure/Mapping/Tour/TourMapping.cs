using AutoMapper;
using Tam.Application.Dtos.TourDtos;
using Tam.Domain.Entities;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Infrastructure.Mapping
{
    public class TourMapping : Profile
    {
        public TourMapping()
        {
            CreateMap<Tour, TourListDto>()
                .ForMember(d => d.StartLocationName, opt => opt.MapFrom(s => s.StartLocation != null ? s.StartLocation.Name : null))
                .ForMember(d => d.EndLocationName, opt => opt.MapFrom(s => s.EndLocation != null ? s.EndLocation.Name : null))
                .ForMember(d => d.GuideName, opt => opt.MapFrom(s => s.Guide.FullName))
                .ForMember(d => d.CategoryName, opt => opt.MapFrom(s => s.Category != null ? s.Category.Name : null));

            CreateMap<Tour, TourDetailDto>()
                .IncludeBase<Tour, TourListDto>()
                .ForMember(d => d.AppranteeName, opt => opt.MapFrom(s => s.Apprantee.FullName))
                .ForMember(d => d.Route, opt => opt.MapFrom(s => s.Route))
                .ForMember(d => d.Vehicles, opt => opt.MapFrom(s => s.TourVehicles))
                .ForMember(d => d.Drivers, opt => opt.MapFrom(s => s.TourDrivers))
                .ForMember(d => d.Hotels, opt => opt.MapFrom(s => s.TourHotels))
                .ForMember(d => d.Regions, opt => opt.MapFrom(s => s.TourRegions));

            CreateMap<TourVehicle, TourVehicleDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Vehicle.Id))
                .ForMember(d => d.PlateNumber, opt => opt.MapFrom(s => s.Vehicle.PlateNumber))
                .ForMember(d => d.Brand, opt => opt.MapFrom(s => s.Vehicle.Brand))
                .ForMember(d => d.Model, opt => opt.MapFrom(s => s.Vehicle.Model))
                .ForMember(d => d.Capacity, opt => opt.MapFrom(s => s.Vehicle.Capacity));

            CreateMap<TourDriver, TourDriverDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Driver.Id))
                .ForMember(d => d.FullName, opt => opt.MapFrom(s => s.Driver.FullName))
                .ForMember(d => d.PhoneNumber, opt => opt.MapFrom(s => s.Driver.PhoneNumber));

            CreateMap<TourHotel, TourHotelDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Hotel.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Hotel.Name))
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s => s.Hotel.Location != null ? $"{s.Hotel.Location.City} - {s.Hotel.Location.District}" : null));

            CreateMap<TourRegion, TourRegionDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Region.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Region.Name));

            CreateMap<Route, TourRouteDto>();
            CreateMap<RouteStop, TourRouteStopDto>()
                .ForMember(d => d.LocationName, opt => opt.MapFrom(s => s.Location.Name));

            CreateMap<CreateTourDto, Tour>();
            CreateMap<UpdateTourDto, Tour>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));

            CreateMap<Tour, TourSearchResultDto>();
        }
    }
}