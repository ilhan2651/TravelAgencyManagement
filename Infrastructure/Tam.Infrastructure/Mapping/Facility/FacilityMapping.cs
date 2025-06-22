using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Facility;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class FacilityMapping : Profile
    {
        public FacilityMapping()
        {
            CreateMap<Facility, ListFacilityDto>();
            CreateMap<Facility, FacilityDetailDto>();

            CreateMap<CreateFacilityDto, Facility>();
            CreateMap<UpdateFacilityDto, Facility>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));
        }
    }

}
