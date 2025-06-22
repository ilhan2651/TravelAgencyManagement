using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.PaymentMethodDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class PaymentMethodMapping : Profile
    {
        public PaymentMethodMapping()
        {
            CreateMap<CreatePaymentMethodDto, PaymentMethod>();
            CreateMap<UpdatePaymentMethodDto, PaymentMethod>();
            CreateMap<PaymentMethod,ListPaymentMethodDto>();
        }
    }
}
