using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.VehicleDto;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class VehicleMapping : Profile
    {
        public VehicleMapping()
        {
            CreateMap<Vehicle,SupplierVehicleDto>();
        }
    }
}
