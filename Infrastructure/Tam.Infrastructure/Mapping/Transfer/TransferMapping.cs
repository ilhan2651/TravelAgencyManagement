using AutoMapper;
using Tam.Application.Dtos.Transfer;
using Tam.Domain.Entities;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Infrastructure.Mapping.Transfer
{
    public class TransferMapping : Profile
    {
        public TransferMapping()
        {
            CreateMap<Transfer, TransferListDto>()
                .ForMember(dest => dest.StartLocationName, opt => opt.MapFrom(src => src.StartLocation.Name))
                .ForMember(dest => dest.EndLocationName, opt => opt.MapFrom(src => src.EndLocation.Name));

            CreateMap<Transfer, TransferDetailDto>()
                .ForMember(dest => dest.StartLocationName, opt => opt.MapFrom(src => src.StartLocation.Name))
                .ForMember(dest => dest.EndLocationName, opt => opt.MapFrom(src => src.EndLocation.Name))
                .ForMember(dest => dest.Route, opt => opt.MapFrom(src => src.Route))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.TransferReservations.Select(tr => tr.Customer)))
                .ForMember(dest => dest.Drivers, opt => opt.MapFrom(src => src.DriverTransfers.Select(dt => dt.Driver)))
                .ForMember(dest => dest.Vehicles, opt => opt.MapFrom(src => src.TransferVehicles.Select(tv => tv.Vehicle)))
                .ForMember(dest => dest.AppranteName, opt => opt.MapFrom(src => src.Apprantee.FullName))
                .ForMember(dest => dest.AppranteePhoneNumber, opt => opt.MapFrom(src => src.Apprantee.PhoneNumber));



            CreateMap<Route, TransferRouteDto>();

            CreateMap<RouteStop, TransferRouteStopDto>()
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Location.Name));

            CreateMap<Customer, TransferCustomerDto>();

            CreateMap<Driver, TransferDriverDto>();

            CreateMap<Vehicle, TransferVehicleDto>();

            CreateMap<CreateTransferDto, Transfer>();
            CreateMap<UpdateTransferDto, Transfer>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));
        }
    }
}
