using AutoMapper;
using Tam.Application.Dtos.DiscountDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class DiscountMapping : Profile
    {
        public DiscountMapping()
        {
            CreateMap<CreateDiscountDto, Discount>();
            CreateMap<UpdateDiscountDto, Discount>()
                .ForAllMembers(opt => opt.Condition((src, _, val) => val is not null));
            CreateMap<Discount, ListDiscountDto>();
        }
    }
}
