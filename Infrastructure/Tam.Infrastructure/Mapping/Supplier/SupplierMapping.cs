using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Supplier;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class SupplierMapping : Profile
    {
        public SupplierMapping()
        {
            CreateMap<CreateSupplierDto, Supplier>();   
            CreateMap<UpdateSupplierDto, Supplier>();
            CreateMap<Supplier,SupplierListDto>();
        }
    }
}
