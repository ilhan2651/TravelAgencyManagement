using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.PaymentDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class PaymentMapping : Profile
    {
        public PaymentMapping()
        {
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val != null));
            CreateMap<Payment, PaymentListDto>()
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Method));  
            CreateMap<Payment, PaymentDetailDto>()
                .ForMember(dest => dest.PaymentMethodName, opt => opt.MapFrom(src => src.PaymentMethod.Method));
        }
    }
}
