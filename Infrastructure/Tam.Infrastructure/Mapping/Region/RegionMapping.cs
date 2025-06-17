using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Region;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class RegionMapping : Profile
    {
        public RegionMapping() 
        {
            CreateMap<Region,RegionListDto>();
            CreateMap<CreateRegionDto, Region> ();
            CreateMap<UpdateRegionDto, Region>();
        }
    }
}
