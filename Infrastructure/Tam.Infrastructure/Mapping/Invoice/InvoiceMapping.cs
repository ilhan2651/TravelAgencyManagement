using AutoMapper;
using Tam.Application.Dtos.InvoiceDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class InvoiceMapping : Profile
    {
        public InvoiceMapping()
        {
            CreateMap<Invoice, ListInvoiceDto>()
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.FullName));

            CreateMap<Invoice, InvoiceDetailDto>()
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.FullName))
                .ForMember(d => d.TourName, o => o.MapFrom(s => s.TourReservation.Tour.Name))
                .ForMember(d => d.HotelName, o => o.MapFrom(s => s.HotelReservation.Hotel.Name))
                .ForMember(d => d.TransferName, o => o.MapFrom(s => s.TransferReservation.Transfer.Name));

            CreateMap<Invoice, SearchInvoiceDto>()
                .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Customer.FullName));

            CreateMap<CreateInvoiceDto, Invoice>();

            CreateMap<UpdateInvoiceDto, Invoice>()
                .ForAllMembers(opt => opt.Condition((src, _, value) => value is not null));
        }
    }
}
