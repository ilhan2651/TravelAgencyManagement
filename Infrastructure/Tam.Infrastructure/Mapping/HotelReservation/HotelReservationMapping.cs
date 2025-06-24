using AutoMapper;
using Tam.Application.Dtos.HotelReservationDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class HotelReservationMapping : Profile
    {
        public HotelReservationMapping()
        {
            CreateMap<CreateHotelReservationDto, HotelReservation>()
                .ForMember(dest => dest.ReservedRooms, opt => opt.Ignore())
                .ForMember(dest => dest.Guests, opt => opt.Ignore());

            
            CreateMap<UpdateHotelReservationDto, HotelReservation>()
                .ForMember(dest => dest.ReservedRooms, opt => opt.Ignore())
                .ForMember(dest => dest.Guests, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));

            CreateMap<ReservedRoomDto, HotelReservationRoomOption>();

            CreateMap<HotelReservation, HotelReservationSearchResultDto>()
    .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer.FullName))
    .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name));


            CreateMap<HotelReservationGuestDto, HotelReservationGuest>();

            CreateMap<HotelReservation, ListHotelReservationDto>()
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name));

            CreateMap<HotelReservation, HotelReservationDetailDto>()
                .ForMember(dest => dest.CustomerFullName, opt => opt.MapFrom(src => src.Customer.FullName))
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Hotel.Name))
                .ForMember(dest => dest.DiscountName, opt => opt.MapFrom(src => src.Discount != null ? src.Discount.Name : null))
                .ForMember(dest => dest.PaymentType, opt => opt.MapFrom(src => src.Payment != null ? src.Payment.PaymentMethod : null))
                .ForMember(dest => dest.ReservedRooms, opt => opt.MapFrom(src => src.ReservedRooms))
                .ForMember(dest => dest.Guests, opt => opt.MapFrom(src => src.Guests));

            CreateMap<HotelReservationRoomOption, ReservedRoomDetailDto>()
                .ForMember(dest => dest.RoomTypeName, opt => opt.MapFrom(src => src.HotelRoomOption.RoomType.Name))
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.HotelRoomOption.PricePerNight))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

            CreateMap<HotelReservationGuest, HotelReservationGuestDto>();
        }
    }
}
