using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.CustomerDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class CustomerMapping : Profile
    {
        public CustomerMapping()
        {
            CreateMap<CreateCustomerDto,Customer>();
            CreateMap<UpdateCustomerDto,Customer>();
            CreateMap<Customer,CustomerListDto>();
        }
    }
}
