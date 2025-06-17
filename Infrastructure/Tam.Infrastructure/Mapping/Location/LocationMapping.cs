using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.LocationDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class LocationMapping : Profile
    {
        public LocationMapping()
        {
            CreateMap<Location, LocationListDto>();
            CreateMap<CreateLocationDto, Location>();
            CreateMap<UpdateLocationDto, Location>();
                

            
        }
    }
}
