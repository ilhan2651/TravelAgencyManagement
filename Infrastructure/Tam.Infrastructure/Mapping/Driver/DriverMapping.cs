using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.DriverDto;
using Tam.Application.Dtos.DriverDtos;
using Tam.Domain.Entities;
using Tam.Domain.Entities.JoinTables;

namespace Tam.Infrastructure.Mapping
{
    public class DriverMapping : Profile
    {
        public DriverMapping()
        {
            CreateMap<Driver, SupplierDriverDto>();
            CreateMap<CreateDriverDto, Driver>();
            CreateMap<UpdateDriverDto, Driver>();


            CreateMap<Driver, DriverDetailDto>()
           .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null))
           .ForMember(dest => dest.Tours, opt => opt.MapFrom(src => src.TourDrivers))
           .ForMember(dest => dest.Transfers, opt => opt.MapFrom(src => src.DriverTransfers))
           .ForMember(dest => dest.DriverLocations, opt => opt.MapFrom(src => src.DriverLocations));

            CreateMap<TourDriver, DriverTourDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Tour.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Tour.Name))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Tour.StartDate))
                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Tour.EndDate));

            CreateMap<DriverTransfer, DriverTransferDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Transfer.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Transfer.Name))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Transfer.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.Transfer.EndTime));

            CreateMap<DriverLocation, DriverLocation>();

            CreateMap<Driver, DriverListDto>()
               .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : string.Empty))
               .ForMember(dest => dest.DriverLocations, opt => opt.MapFrom(src => src.DriverLocations));

            CreateMap<Driver, DriverSearchResultDto>();

        }
    }
}
