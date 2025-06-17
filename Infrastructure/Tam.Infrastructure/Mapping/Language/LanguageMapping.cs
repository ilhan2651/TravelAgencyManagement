using AutoMapper;
using Tam.Application.Dtos.Language;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class LanguageMapping : Profile
    {
        public LanguageMapping()
        {
            CreateMap<CreateLanguageDto, Language>();
            CreateMap<UpdateLanguageDto, Language>();
            CreateMap<Language, LanguageListDto>();
        }
    }
}
