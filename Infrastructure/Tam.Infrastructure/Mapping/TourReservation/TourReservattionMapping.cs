using AutoMapper;
using Tam.Application.Dtos.TourReservationDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class TourReservationMapping : Profile
    {
        public TourReservationMapping()
        {
            CreateMap<CreateTourReservationDto, TourReservation>();

            CreateMap<UpdateTourReservationDto, TourReservation>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));

            CreateMap<TourReservation, TourReservationDetailDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour.Name))
                 .ForMember(dest => dest.TourReservationGuestListDtos, opt => opt.MapFrom(src => src.Guests))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.DiscountName, opt => opt.MapFrom(src => src.Discount != null ? src.Discount.Name : null));


            CreateMap<TourReservation, ListTourReservationDto>()
                .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour.Name))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName));
            CreateMap<CreateTourReservationGuestsDto, TourReservationGuest>();

            CreateMap<CreateTourReservationDto, TourReservation>()
                .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.Guests));

            CreateMap<UpdateTourReservationGuestDto, TourReservationGuest>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id.HasValue));

            CreateMap<TourReservationGuest, TourReservationGuestListDto>();

            CreateMap<TourReservation, TourReservationSearchResultDto>()
    .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.FullName))
    .ForMember(dest => dest.TourName, opt => opt.MapFrom(src => src.Tour.Name));
    

        }
    }
}