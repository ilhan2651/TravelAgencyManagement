using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.VehicleDto;
using Tam.Application.Dtos.VehicleDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class VehicleMapping : Profile
    {
        public VehicleMapping()
        {

            CreateMap<Vehicle,SupplierVehicleDto>();
            CreateMap<CreateVehicleDto, Vehicle>();
            CreateMap<UpdateVehicleDto, Vehicle>();

            CreateMap<Vehicle, VehicleListDto>()
                .ForMember(dest => dest.SupplierName,
                opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null));

            CreateMap<Vehicle, VehicleDetailDto>()
              .ForMember(dest => dest.SupplierName,
                         opt => opt.MapFrom(src => src.Supplier != null ? src.Supplier.Name : null))
              .ForMember(dest => dest.Tours,
                         opt => opt.MapFrom(src => src.TourVehicles))
              .ForMember(dest => dest.Transfers,
                         opt => opt.MapFrom(src => src.TransferVehicles));

            CreateMap<TourVehicle, VehicleTourDto>()
             .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Tour.Id))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Tour.Name))
             .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.Tour.StartDate))
             .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.Tour.EndDate));

            CreateMap<TransferVehicle, VehicleTransferDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Transfer.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Transfer.Name))
                .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.Transfer.StartTime))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.Transfer.EndTime));
            CreateMap<Vehicle, VehicleSearchResultDto>();

        }
    }
}
