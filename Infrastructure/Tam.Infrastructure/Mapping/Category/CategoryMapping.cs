using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.CategoryDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class CategoryMapping : Profile
    {
        public CategoryMapping()
        {
            CreateMap<CreateCategoryDto,Category>();
            CreateMap<UpdateCategoryDto,Category>();
            CreateMap<Category,CategoryDetailDto>();
            CreateMap<Category,CategoryListDto>();
        }
    }
}
