using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tam.Application.Dtos.UserDtos;
using Tam.Domain.Entities;

namespace Tam.Infrastructure.Mapping
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User,UserListDto>().ReverseMap();
            CreateMap<User, UserDeletedListDto>().ReverseMap();

        }
    }
}
