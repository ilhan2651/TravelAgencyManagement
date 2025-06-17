using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.Aprantee;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class AppranteeMapping : Profile
    {
        public AppranteeMapping()
        {
            CreateMap<Apprantee,ListAppranteeDto>();
            CreateMap<CreateAppranteeDto,Apprantee > ();
            CreateMap<UpdateAppranteeDto, Apprantee>();
        }
    }
}
