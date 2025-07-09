using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.TransferReservationDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class TransferReservationMapping : Profile
    {
        public TransferReservationMapping()
        {
            CreateMap<CreateTransferReservationGuestsDto, TransferReservationGuest>();

            CreateMap<CreateTransferReservationDto, TransferReservation>()
                .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.Guests));

            CreateMap<UpdateTransferReservationGuestDto, TransferReservationGuest>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id.HasValue));

            CreateMap<UpdateTransferReservationDto, TransferReservation>();

            CreateMap<TransferReservationGuest, TransferReservationGuestListDto>();

            CreateMap<TransferReservation, TransferReservationDetailDto>()
                .ForMember(dest => dest.TransferName, opt => opt.MapFrom(src => src.Transfer.Name))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.DiscountName, opt => opt.MapFrom(src => src.Discount != null ? src.Discount.Name : string.Empty))
                .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.Guests));

            CreateMap<TransferReservation, TransferReservationSearchResultDto>()
                   .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));
            CreateMap<TransferReservation, ListTransferReservationDto>()
               .ForMember(d => d.TransferName, o => o.MapFrom(s => s.Transfer.Name))
               .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.FullName));

        }
    }

}
